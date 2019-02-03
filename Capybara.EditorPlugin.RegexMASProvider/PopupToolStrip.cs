using System;
using System.Drawing;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.Models;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    public class PopupToolStrip
    {
        private readonly ToolStripDropDown _toolStripDropDown;
        private readonly ToolStripControlHost _toolStripControlHost;
        private readonly PopupWindow _popupWindow;

        public PopupToolStrip()
        {
            _toolStripDropDown = new ToolStripDropDown
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoClose = true,
                DropShadowEnabled = true
            };
            _popupWindow = new PopupWindow();
            _popupWindow.CloseEventHandler += _popupWindow_CloseEventHandler;
            _toolStripControlHost = new ToolStripControlHost(_popupWindow)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };
            _toolStripDropDown.Items.Add(_toolStripControlHost);
        }

        void _popupWindow_CloseEventHandler(object sender, EventArgs e)
        {
            var itemString = _popupWindow.GetSelectedItem();
            _toolStripDropDown.Close();
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

        public void Show(Point caretPosition, PopupWindowContent content)
        {
            _toolStripDropDown.Show(caretPosition);
            _popupWindow.SetContent(content);
        }
    }
}
