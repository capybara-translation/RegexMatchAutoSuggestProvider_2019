using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.Models;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    [Action("RegexMASProviderAction", typeof (EditorController), Name = "RegexMASProviderAction_Name",
        Description = "RegexMASProviderAction_Description", Icon = "RegexMASProvider_Icon")]
    [ActionLayout(typeof (TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1, DisplayType.Large)
    ]
    [Shortcut(Keys.Control | Keys.Shift | Keys.F12)]
    public class ShowPopupAction : AbstractViewControllerAction<EditorController>
    {
        private PopupToolStrip _popupToolStrip;

        public override void Initialize()
        {
            _popupToolStrip = new PopupToolStrip();
        }

        protected override void Execute()
        {
            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            var document = editorController.ActiveDocument;
            if (document == null)
            {
                return;
            }
            var viewPartController =
                SdlTradosStudio.Application.GetController<RegexMatchAutoSuggestProviderViewPartController>();
            if (viewPartController == null)
            {
                return;
            }
            var regexPatternEntries = viewPartController.GetRegexPattenEntries();
            if (regexPatternEntries == null)
            {
                return;
            }

            var segmentPair = document.ActiveSegmentPair;
            if (segmentPair == null)
            {
                return;
            }
            if (document.FocusedDocumentContent != FocusedDocumentContent.Target)
            {
                return;
            }

            var activeProcess = CaretPositionUtils.GetActiveProcess();
            if (activeProcess != "SDLTradosStudio")
            {
                return;
            }

            var text =
                segmentPair.Source.AllSubItems.OfType<IText>()
                    .Aggregate(new StringBuilder(), (builder, it) => builder.Append(it.Properties.Text))
                    .ToString();
            var suggestions = new List<string>();
            Task.Factory.StartNew(
                () =>
                {
                    var variables = viewPartController.GetVariables();
                    suggestions.AddRange(
                        regexPatternEntries.EvaluateMatches(text, variables).OrderByDescending(s => s.Length));
                })
                .ContinueWith(_ =>
                {
                    if (suggestions.Count > 0)
                    {
                        var content = new PopupWindowContent { Suggestions = suggestions };
                        var caretPosition = CaretPositionUtils.GetCaretPosition();
                        _popupToolStrip.Show(caretPosition, content);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}