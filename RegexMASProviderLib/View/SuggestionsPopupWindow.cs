using System;
using System.Linq;
using System.Windows.Forms;

namespace RegexMASProviderLib.View
{
    public partial class SuggestionsPopupWindow : BasePopupUserControl
    {
        public SuggestionsPopupWindow()
        {
            InitializeComponent();
        }

        public event EventHandler CloseEventHandler;

        public override void SetContent(PopupWindowContent content)
        {
            suggestionsListBox.Items.Clear();
            suggestionsListBox.Items.AddRange(content.AutoSuggestEntries
                .Select(e => e.AutoSuggestString)
                .Distinct()
                .OrderBy(s => s)
                .ToArray<object>());
            if (suggestionsListBox.Items.Count > 0)
            {
                suggestionsListBox.SelectedIndex = 0;
            }
            Focus();
        }

        public string GetSelectedItem()
        {
            if (suggestionsListBox.Items.Count > 0)
            {
                return suggestionsListBox.SelectedItem.ToString();
            }
            return string.Empty;
        }

        private void suggestionsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CloseEventHandler != null)
            {
                CloseEventHandler(sender, e);
            }
        }

        private void suggestionsListBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyData == Keys.Enter && CloseEventHandler != null)
            {
                CloseEventHandler(sender, e);
            }
        }

    }
}
