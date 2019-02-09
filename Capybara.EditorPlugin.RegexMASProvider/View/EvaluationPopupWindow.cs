using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.Models;

namespace Capybara.EditorPlugin.RegexMASProvider.View
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

            lstEntries.DataSource = content.AutoSuggestEntries.OrderBy(x => x.OriginalFindPattern).ToList();
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
