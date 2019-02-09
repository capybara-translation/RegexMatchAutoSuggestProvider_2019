using System;
using System.Linq;
using System.Windows.Forms;
using RegexMASProviderLib.Models;

namespace RegexMASProviderLib.View
{
    public partial class EvaluationPopupWindow : BasePopupUserControl
    {
        public EvaluationPopupWindow()
        {
            InitializeComponent();
        }

        public event EventHandler CloseEventHandler;

        public override void SetContent(PopupWindowContent content)
        {

            lstEntries.DataSource = content.AutoSuggestEntries.OrderBy(x => x.AutoSuggestString).ToList();
            lstEntries.DisplayMember = "AutoSuggestString";
            //lstEntries.Items.Clear();
            //lstEntries.Items.AddRange(content.AutoSuggestEntries.Select(e => e.AutoSuggestString).ToArray<object>());
            if (lstEntries.Items.Count > 0)
            {
                lstEntries.SelectedIndex = 0;
            }
            Focus();
        }

        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (AutoSuggestEntry)((ListBox) sender).SelectedItem;
        }
    }
}
