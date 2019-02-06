using System.ComponentModel;
using System.Windows.Forms;

namespace Capybara.EditorPlugin.RegexMASProvider.View
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractPopupUserControl, UserControl>))]
    [ConcreteClass(typeof(SuggestionsPopupWindow))]
    public abstract class AbstractPopupUserControl : UserControl
    {
        public abstract void SetContent(PopupWindowContent content);
    }
}