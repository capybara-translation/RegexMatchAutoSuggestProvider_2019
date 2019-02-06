using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.View;
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
        private PopupToolStripController _popupToolStrip;
        private SuggestionsPopupWindow _suggestionsPopupWindow;

        public override void Initialize()
        {
            _suggestionsPopupWindow = new SuggestionsPopupWindow();
            _popupToolStrip = new PopupToolStripController(_suggestionsPopupWindow);
            _suggestionsPopupWindow.CloseEventHandler += PopupWindow_CloseEventHandler;
        }

        private void PopupWindow_CloseEventHandler(object sender, System.EventArgs e)
        {
            var itemString = _suggestionsPopupWindow.GetSelectedItem();
            _popupToolStrip.ToolStripDropDown.Close();
            InsertItemString(itemString);
        }

        private void InsertItemString(string itemString)
        {
            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            if (editorController == null)
            {
                return;
            }
            var doc = editorController.ActiveDocument;
            if (doc == null)
            {
                return;
            }
            if (doc.Selection.Current is SourceSelection || doc.ActiveSegmentPair == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(itemString))
            {
                doc.Selection.Target.Replace(itemString, "Text inserted by Regex Match AutoSuggest Provider");
                doc.Selection.Current.Collapse();
            }
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

            // TODO: 正規表現も見せる
            var text = string.Join("", segmentPair.Source.AllSubItems.OfType<IText>().Select(txt => txt.Properties.Text));
            var suggestions = new List<string>();
            Task.Factory.StartNew(
                () =>
                {
                    var variables = viewPartController.GetVariables();
                    suggestions.AddRange(
                        regexPatternEntries.GetAutoSuggestEntries(text, variables).OrderByDescending(s => s.Length));
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