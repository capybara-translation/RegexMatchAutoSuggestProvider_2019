using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegexMASProviderLib.Models;
using RegexMASProviderLib.View;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Capybara.EditorPlugin.RegexMASProvider_2017
{
    [Action("SuggestionsPopupWindowAction", typeof (EditorController), Name = "SuggestionsPopupWindowAction_Name",
        Description = "SuggestionsPopupWindowAction_Description", Icon = "RegexMASProvider_Icon")]
    [ActionLayout(typeof (TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1, DisplayType.Large)
    ]
    [Shortcut(Keys.Control | Keys.Shift | Keys.F12)]
    public class SuggestionsPopupWindowAction : AbstractViewControllerAction<EditorController>
    {
        private PopupToolStripController _popupToolStrip;
        private SuggestionsPopupWindow _popupWindow;

        public override void Initialize()
        {
            _popupWindow = new SuggestionsPopupWindow();
            _popupToolStrip = new PopupToolStripController(_popupWindow);
            _popupWindow.CloseEventHandler += PopupWindow_CloseEventHandler;
            base.Initialize();
        }

        private void PopupWindow_CloseEventHandler(object sender, System.EventArgs e)
        {
            var itemString = _popupWindow.GetSelectedItem();
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
            var regexPatternEntries = viewPartController.RegexPatternEntries;
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

            var activeProcess = CaretPosition.GetActiveProcess();
            if (activeProcess != "SDLTradosStudio")
            {
                return;
            }

            var text = string.Join("", segmentPair.Source.AllSubItems.OfType<IText>().Select(txt => txt.Properties.Text));
            Task<List<AutoSuggestEntry>>.Factory.StartNew(
                () =>
                {
                    var variables = viewPartController.Variables;
                    return regexPatternEntries.GetAutoSuggestEntries(text, variables);
                })
                .ContinueWith(task => 
                {
                    if (task.Result.Count > 0)
                    {
                        var content = new PopupWindowContent(task.Result);
                        var caretPosition = CaretPosition.EvaluateCarePosition();
                        _popupToolStrip.Show(caretPosition, content);
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}