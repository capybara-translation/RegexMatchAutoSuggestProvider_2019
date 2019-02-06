using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Capybara.EditorPlugin.RegexMASProvider.Models;
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
        private RegexPattenEntries _regexPatternEntries;
        private Variables _variables;
        private ListChangeNotifier _listChangeNotifier;
        private RegexMatchAutoSuggestProviderViewPartController _viewPartController;

        public RegexMatchAutoSuggestProvider()
        {
            _viewPartController =
                SdlTradosStudio.Application.GetController<RegexMatchAutoSuggestProviderViewPartController>();
            if (_viewPartController != null)
            {
                _regexPatternEntries = _viewPartController.GetRegexPattenEntries();
                _variables = _viewPartController.GetVariables();

                _listChangeNotifier = _viewPartController.GetListChangeNotifier();
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
                    _regexPatternEntries = _viewPartController.GetRegexPattenEntries();
                }
                if (_variables == null)
                {
                    _variables = _viewPartController.GetVariables();
                }
                if (_listChangeNotifier == null)
                {
                    _listChangeNotifier = _viewPartController.GetListChangeNotifier();
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
                _candidates.AddRange(_regexPatternEntries.GetAutoSuggestEntries(text, _variables));
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