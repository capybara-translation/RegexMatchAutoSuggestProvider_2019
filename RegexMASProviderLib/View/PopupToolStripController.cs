using System.Drawing;
using System.Windows.Forms;

namespace RegexMASProviderLib.View
{
    public class PopupToolStripController
    {
        public BasePopupUserControl PopupWindow { get; }
        public ToolStripControlHost ToolStripControlHost { get; }
        public ToolStripDropDown ToolStripDropDown { get; }

        public PopupToolStripController(BasePopupUserControl popupUserControl)
        {
            ToolStripDropDown = new ToolStripDropDown
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoClose = true,
                DropShadowEnabled = true
            };
            PopupWindow = popupUserControl;
            ToolStripControlHost = new ToolStripControlHost(PopupWindow)
            {
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                AutoSize = false
            };
            ToolStripDropDown.Items.Add(ToolStripControlHost);
        }

        public void Show(Point caretPosition, PopupWindowContent content)
        {
            ToolStripDropDown.Show(caretPosition);
            PopupWindow.SetContent(content);
        }
    }
}
