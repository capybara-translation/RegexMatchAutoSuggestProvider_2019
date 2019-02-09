using System;
using System.Windows.Forms;

namespace RegexMASProviderLib.View
{
    public class BasePopupUserControl : UserControl
    {
        public virtual void SetContent(PopupWindowContent content)
        {
            throw new NotImplementedException("This method must be overridden");
        }
    }
}