using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.Models;
using Capybara.EditorPlugin.RegexMASProvider.View;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.TranslationStudioAutomation.IntegrationApi;
using Sdl.TranslationStudioAutomation.IntegrationApi.Presentation.DefaultLocations;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    [Action("EvaluationPopupWindowAction", typeof (EditorController), Name = "EvaluationPopupWindowAction_Name",
        Description = "EvaluationPopupWindowAction_Description", Icon = "RegexMASProvider_Icon")]
    [ActionLayout(typeof (TranslationStudioDefaultContextMenus.EditorDocumentContextMenuLocation), 1, DisplayType.Large)
    ]
    [Shortcut(Keys.Control | Keys.Shift | Keys.F11)]
    public class EvaluationPopupWindowAction : AbstractViewControllerAction<EditorController>
    {
        private PopupToolStripController _popupToolStrip;
        private EvaluationPopupWindow _popupWindow;

        public override void Initialize()
        {
            _popupWindow = new EvaluationPopupWindow();
            _popupToolStrip = new PopupToolStripController(_popupWindow);
            _popupWindow.CloseEventHandler += _popupWindow_CloseEventHandler;
            base.Initialize();
        }

        private void _popupWindow_CloseEventHandler(object sender, System.EventArgs e)
        {
            _popupToolStrip.ToolStripDropDown.Close();
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

            var activeProcess = CaretPosition.GetActiveProcess();
            if (activeProcess != "SDLTradosStudio")
            {
                return;
            }

            var text = string.Join("", segmentPair.Source.AllSubItems.OfType<IText>().Select(txt => txt.Properties.Text));
            Task<List<AutoSuggestEntry>>.Factory.StartNew(
                () =>
                {
                    var variables = viewPartController.GetVariables();
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