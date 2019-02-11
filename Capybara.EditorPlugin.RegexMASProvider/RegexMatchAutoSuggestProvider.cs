using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RegexMASProviderLib.Models;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.AutoSuggest;
using Sdl.TranslationStudioAutomation.IntegrationApi.Extensions;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    [AutoSuggestProvider(Id = "RegexMatchAutoSuggestProvider", Name = "RegexMatchAutoSuggestProvider",
        Description = "AutoSuggest provider for copying the source words that match the specified regular expressions",
        Icon = "RegexMASProvider_Icon")]
    public class RegexMatchAutoSuggestProvider : AbstractAutoSuggestProvider
    {
        private List<string> _candidates;
        private RegexPatternEntries _regexPatternEntries;
        private Variables _variables;
        private ListChangeNotifier _listChangeNotifier;
        private RegexMatchAutoSuggestProviderViewPartController _viewPartController;

        public RegexMatchAutoSuggestProvider()
        {
            _viewPartController =
                SdlTradosStudio.Application.GetController<RegexMatchAutoSuggestProviderViewPartController>();
            if (_viewPartController != null)
            {
                _regexPatternEntries = _viewPartController.RegexPatternEntries;
                _variables = _viewPartController.Variables;

                _listChangeNotifier = _viewPartController.ListChangeNotifier;
                _listChangeNotifier.Changed += _listChangeNotifier_Changed;
            }
        }

        private void _listChangeNotifier_Changed(object sender, EventArgs e)
        {
            Debug.WriteLine("List Changed");
            InitializeCandidates();
        }

        protected override void OnActiveDocumentChanged()
        {
            if (_viewPartController == null)
            {
                _viewPartController =
                    SdlTradosStudio.Application.GetController<RegexMatchAutoSuggestProviderViewPartController>();
            }
            if (_viewPartController != null)
            {
                if (_regexPatternEntries == null)
                {
                    _regexPatternEntries = _viewPartController.RegexPatternEntries;
                }
                if (_variables == null)
                {
                    _variables = _viewPartController.Variables;
                }
                if (_listChangeNotifier == null)
                {
                    _listChangeNotifier = _viewPartController.ListChangeNotifier;
                    _listChangeNotifier.Changed += _listChangeNotifier_Changed;
                }
                InitializeCandidates();
            }
        }

        private void InitializeCandidates()
        {
            if (_candidates == null)
            {
                _candidates = new List<string>();
            }
            else
            {
                _candidates.Clear();
            }
            var segmentPair = ActiveSegmentPair;
            if (segmentPair != null)
            {
                var text = string.Join("",
                    segmentPair.Source.AllSubItems.OfType<IText>().Select(txt => txt.Properties.Text));
                var autoSuggestEntries = _regexPatternEntries.GetAutoSuggestEntries(text, _variables); 
                _candidates.AddRange(autoSuggestEntries.Select(e => e.AutoSuggestString).Distinct());
            }
        }


        protected override void OnActiveSegmentChanged()
        {
            if (Settings.Enabled && _viewPartController != null)
            {
                InitializeCandidates();
            }
            else
            {
                _candidates = null;
            }
        }

        protected override void OnSettingsChanged()
        {
            if (Settings.Enabled && _viewPartController != null)
            {
                InitializeCandidates();
            }
            else
            {
                _candidates = null;
            }
        }

        protected override IEnumerable<AbstractAutoSuggestResult> GetSuggestions(AbstractEditingContext context)
        {
            if (Settings.Enabled)
            {
                string prefix = context.GetAllPrefixes().FirstOrDefault();
                if (!string.IsNullOrEmpty(prefix) && _candidates != null && _candidates.Count > 0)
                {
                    return _candidates.Where(
                        item =>
                            item.StartsWith(prefix,
                                Settings.CaseSensitive
                                    ? StringComparison.InvariantCulture
                                    : StringComparison.InvariantCultureIgnoreCase)).Select(
                                        item =>
                                        {
                                            var result = new AutoSuggestTextResult(context, item)
                                            {
                                                Priority = Settings.Priority,
                                                Icon = Icon
                                            };
                                            return result;
                                        });
                }
            }
            return null;
        }
    }
}