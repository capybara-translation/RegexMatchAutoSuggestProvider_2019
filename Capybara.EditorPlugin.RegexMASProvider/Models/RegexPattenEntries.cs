using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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