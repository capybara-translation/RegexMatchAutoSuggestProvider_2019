using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capybara.EditorPlugin.RegexMASProvider.View
{
    public class BasePopupUserControl : UserControl
    {
        public virtual void SetContent(PopupWindowContent content)
        {
            throw new NotImplementedException("This method must be overridden");
        }
    }
}