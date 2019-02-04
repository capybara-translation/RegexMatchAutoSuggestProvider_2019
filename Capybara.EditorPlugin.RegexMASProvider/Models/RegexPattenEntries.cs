using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Capybara.EditorPlugin.RegexMASProvider.Common;

namespace Capybara.EditorPlugin.RegexMASProvider.Models
{
    public class RegexPattenEntries : ModelBase
    {
        private static readonly string FileNameSuffix = ".settings.xml";

        private BindingList<RegexPatternEntry> _entries;

        public BindingList<RegexPatternEntry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged("Entries");
            }
        }

        public RegexPattenEntries()
        {
            Entries = new BindingList<RegexPatternEntry>();
            Load();
        }

        public void Load()
        {
            var path = Utils.GetSettingsPath(FileNameSuffix);
            if (!File.Exists(path))
            {
                return;
            }
            var doc = XDocument.Load(path);
            foreach (var entry in doc.Descendants("Entry"))
            {
                var isEnabledElem = entry.Element("IsEnabled");
                var descElem = entry.Element("Description");
                var regexPatternElem = entry.Element("RegexPattern");
                var replacePatternElem = entry.Element("ReplacePattern");

                Entries.Add(new RegexPatternEntry
                {
                    IsEnabled = isEnabledElem != null ? bool.Parse(isEnabledElem.Value) : true,
                    Description = descElem != null ? descElem.Value : string.Empty,
                    RegexPattern = regexPatternElem != null ? regexPatternElem.Value : string.Empty,
                    ReplacePattern = replacePatternElem != null ? replacePatternElem.Value : string.Empty
                });
            }
        }

        public void Save()
        {
            var path = Utils.GetSettingsPath(FileNameSuffix);
            var doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("RegexMatchAutoSuggestProvider",
                    new XElement("Settings",
                        new XElement("RegexPatternEntries",
                            Entries.Select(e =>
                                new XElement("Entry",
                                    new XElement("IsEnabled", e.IsEnabled),
                                    new XElement("Description", e.Description),
                                    new XElement("RegexPattern", e.RegexPattern),
                                    new XElement("ReplacePattern", e.ReplacePattern)))
                            ))));
            doc.Save(path);
        }

        public override string Error
        {
            get { return null; }
        }

        public List<string> EvaluateMatches(string text, Variables variables)
        {
            var results = new List<string>();
            if (!string.IsNullOrEmpty(text))
            {
                var validVariables = DistinctVariables(variables);
                foreach (var pattern in Entries.Where(e => e.IsEnabled && !e.HasErrors))
                {
                    var pairPatterns = GetTranslationPairPatterns(validVariables, pattern.RegexPattern);
                    foreach (var pairPattern in pairPatterns)
                    {
                        var findWord = pairPattern.FindWord;
                        var replaceWord = pairPattern.ReplaceWord;
                        var newtext = Regex.Replace(text, pairPattern.OriginalPattern,
                            match => match.Value.Replace(findWord, replaceWord));
                        results.AddRange(from Match match in Regex.Matches(newtext, pairPattern.ModifiedPattern)
                                         select Utils.WideToNarrow(match.Result(pattern.ReplacePattern)));
                    }

                    results.AddRange(from Match match in Regex.Matches(text, pattern.RegexPattern)
                        select Utils.WideToNarrow(match.Result(pattern.ReplacePattern)));
                }
            }
            return results.Select(e => e).Distinct().ToList();
        }


        public List<string> EvaluateMatches2(string text, Variables variables)
        {
            var results = new List<string>();
            if (!string.IsNullOrEmpty(text))
            {
                var validVariables = DistinctVariables(variables);
                foreach (var pattern in Entries.Where(e => e.IsEnabled && !e.HasErrors))
                {
                    var finalRegex = ConstructFinalRegex(validVariables, pattern.RegexPattern);
                    var regex = new Regex(finalRegex.ConcatenatedPattern);
                    var cnt = 0;
                    var newText = regex.Replace(text, match =>
                    {
                        cnt++;
                        var groupNames = regex.GetGroupNames();
                        var entireValue = match.Value;
                        foreach (var groupName in groupNames.Skip(1))
                        {
                            // TODO: 数字グループも処理する
                            var group = match.Groups[groupName];
                            if (!group.Success || !finalRegex.VariableMap.ContainsKey(groupName))
                            {
                                continue;
                            }
                            var variable = finalRegex.VariableMap[groupName];

                            var diff = 0;
                            foreach (Capture capture in group.Captures)
                            {
                                var pair = variable.TranslationPairs.FirstOrDefault(x => !x.HasErrors && Regex.Escape(x.Source) == capture.Value);
                                if (pair == null)
                                {
                                    continue;
                                }

                                var beforeLen = entireValue.Length;
                                entireValue = entireValue.Remove(capture.Index - match.Index - diff, capture.Length);
                                entireValue = entireValue.Insert(capture.Index - match.Index - diff, $"({pair.Target})");
                                var afterLen = entireValue.Length;
                                diff = beforeLen - afterLen;
                            }
                        }

                        return Utils.WideToNarrow(entireValue.ToString());

                    });
                    results.Add(newText);

                    results.AddRange(from Match match in Regex.Matches(text, pattern.RegexPattern)
                                         select Utils.WideToNarrow(match.Result(pattern.ReplacePattern)));

                }
            }
            return results.Select(e => e).Distinct().ToList();
        }

        private class FinalRegex
        {
            public string ConcatenatedPattern { get; set; }
            public Dictionary<string, Variable> VariableMap { get; set; }
        }


        private FinalRegex ConstructFinalRegex(IEnumerable< Variable> variables, string basedPattern)
        {
            var finalRegex = new FinalRegex{
                ConcatenatedPattern = basedPattern,
                VariableMap = new Dictionary<string, Variable>()
            };
            
            foreach (var variable in variables.Where(p => !p.HasErrors && p.IsEnabled))
            {
                if (!finalRegex.ConcatenatedPattern.Contains($"#{variable.Name}#"))
                {
                    continue;
                }
                var groupName = variable.Name;
                var concatenatedSources = string.Join("|", variable.TranslationPairs.Where(p => !p.HasErrors).Select(p => Regex.Escape(p.Source)));
                finalRegex.ConcatenatedPattern = finalRegex.ConcatenatedPattern.Replace($"#{variable.Name}#", $"(?<{groupName}>{concatenatedSources})");
                finalRegex.VariableMap.Add(groupName, variable);
            }

            return finalRegex;
        }

        private List<Variable> DistinctVariables(Variables variables)
        {
            var list = new List<Variable>();
            foreach (var variable in variables.Entries.Where(e => e.IsEnabled && !e.HasErrors))
            {
                if (list.Count == 0 || list.All(e => e.Name != variable.Name))
                {
                    list.Add(variable);
                }
            }
            return list;
        }

        private List<TranslationPairPattern> GetTranslationPairPatterns(List<Variable> variables, string regexPattern)
        {
            var list = new List<TranslationPairPattern>();
            foreach (var variable in variables)
            {
                var varname = "#" + variable.Name + "#";
                if (!regexPattern.Contains(varname))
                {
                    continue;
                }
                foreach (var pair in variable.TranslationPairs.Where(p => !p.HasErrors))
                {
                    //var findPattern = regexPattern.Replace(varname,
                    //    string.Format("(?<{0}>{1})", variable.Name, Regex.Escape(pair.Source)));
                    //var replacePattern = regexPattern.Replace(varname,
                    //    string.Format("(?<{0}>{1})", variable.Name, Regex.Escape(pair.Target)));
                    var findPattern = regexPattern.Replace(varname,
                        string.Format("(?:{0})", Regex.Escape(pair.Source)));
                    var replacePattern = regexPattern.Replace(varname,
                        string.Format("(?:{0})", Regex.Escape(pair.Target)));
                    list.Add(new TranslationPairPattern
                    {
                        OriginalPattern = findPattern,
                        FindWord = pair.Source,
                        ModifiedPattern = replacePattern,
                        ReplaceWord = pair.Target
                    });
                }
            }
            return list;
        }

        private class TranslationPairPattern
        {
            public string OriginalPattern { get; set; }
            public string FindWord { get; set; }
            public string ModifiedPattern { get; set; }
            public string ReplaceWord { get; set; }
        }
    }
}