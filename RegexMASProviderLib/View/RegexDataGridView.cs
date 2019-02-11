using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RegexMASProviderLib.Models;

namespace RegexMASProviderLib.View
{
    public partial class RegexDataGridView : UserControl
    {
        private RegexPatternEntries _regexPatternEntries;
        private Variables _variables;
        private ListChangeNotifier _listChangeNotifier;
        private TabPageManager _tabPageManager;

        public RegexDataGridView()
        {
            InitializeComponent();
            _tabPageManager = new TabPageManager(mainTabControl);
            ShowRegexTester = false;  // Disable RegexTester by default

            enableSelectedRegexEntriesToolStripMenuItem.Tag = true;
            disableSelectedRegexEntriesToolStripMenuItem.Tag = false;
            regexPatternsDataGridView.ContextMenuStrip = regexContextMenuStrip;

            enableSelectedVariableEntriesToolStripMenuItem.Tag = true;
            disableSelectedVariableEntriesToolStripMenuItem.Tag = false;
            variablesDataGridView.ContextMenuStrip = variableContextMenuStrip;
        }

        private bool _showRegexTester;
        public bool ShowRegexTester
        {
            get { return _showRegexTester; }
            set
            {
                _showRegexTester = value;
                _tabPageManager.ChangeTabPageVisible(2, value);
            }

        }

        public void Initialize(RegexPatternEntries regexPatternEntries, Variables variables,
            ListChangeNotifier listChangeNotifier)
        {
            _regexPatternEntries = regexPatternEntries;
            _variables = variables;
            _listChangeNotifier = listChangeNotifier;
            InitializeDataBindings();
        }

        private void InitializeDataBindings()
        {
            regexPatternEntryBindingSource.DataSource = _regexPatternEntries.Entries;
            variableBindingSource.DataSource = _variables.Entries;
            translationPairBindingSource.DataSource = variableBindingSource;
            translationPairBindingSource.DataMember = "TranslationPairs";

            _listChangeNotifier.BindingSources.Add(regexPatternEntryBindingSource);
            _listChangeNotifier.BindingSources.Add(translationPairBindingSource);
            _listChangeNotifier.Start();

            regexPatternsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            variablesDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            translationPairsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void regexPatternsDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            try
            {
                PasteToDGV(dgv, e);
            }
            catch (Exception)
            {

            }
        }

        private void variablesDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            try
            {
                PasteToDGV(dgv, e);
            }
            catch (Exception)
            {

            }
        }

        private void translationPairsDataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv == null)
            {
                return;
            }
            try
            {
                PasteToDGV(dgv, e);
            }
            catch (Exception)
            {
                
            }
            
        }

        private void PasteToDGV(DataGridView dgv, PreviewKeyDownEventArgs e)
        {
            if (dgv.CurrentCell == null)
            {
                return;
            }
            var rowIndex = dgv.CurrentCell.RowIndex;
            var colIndex = dgv.CurrentCell.ColumnIndex;
            var pasteText = Clipboard.GetText();
            if (string.IsNullOrEmpty(pasteText))
            {
                return;
            }
            if ((e.Modifiers & Keys.Control) == Keys.Control && e.KeyCode == Keys.V)
            {
                pasteText = pasteText.Replace("\r\n", "\n");
                pasteText = pasteText.Replace('\r', '\n');
                pasteText = pasteText.TrimEnd('\n');
                var lines = pasteText.Split('\n');
                foreach (var line in lines)
                {
                    var values = line.Split('\t');
                    if (rowIndex == dgv.RowCount - 1 && dgv.AllowUserToAddRows)
                    {
                        var bs = dgv.DataSource as BindingSource;
                        if (bs == null)
                        {
                            return;
                        }
                        bs.AddNew();
                    }
                    for (var i = 0; i <= values.GetLength(0) - 1; i++)
                    {
                        if (colIndex + i < dgv.ColumnCount)
                        {
                            var dgvCell = dgv[colIndex + i, rowIndex];
                            if (!dgvCell.ReadOnly && dgvCell.FormattedValue.ToString() != values[i])
                            {
                                if (dgvCell.ValueType == typeof(bool))
                                {
                                    bool result;
                                    if (bool.TryParse(values[i], out result))
                                    {
                                        dgvCell.Value = result;
                                    }
                                    else
                                    {
                                        dgvCell.Value = true;
                                    }
                                }
                                else
                                {
                                    dgvCell.Value = Convert.ChangeType(values[i], dgvCell.ValueType);
                                }
                            }
                        }
                    }
                    rowIndex++;
                }
            }
        }

        private void translationPairBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new TranslationPair();
        }

        private void variableBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new Variable();
        }

        private void regexPatternEntryBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new RegexPatternEntry();
        }

        private void testButton_Click(object sender, EventArgs e)
        {

            var sourceText = sourceTextBox.Text;
            if (string.IsNullOrEmpty(sourceText))
            {
                return;
            }

            var autoSuggestEntries = _regexPatternEntries.GetAutoSuggestEntries(sourceText, _variables);
            var popupContent = new PopupWindowContent(autoSuggestEntries);
            evaluationPopupWindow.SetContent(popupContent);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            sourceTextBox.Clear();
        }

        private void enableSelectedRegexEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enable = (bool) ((ToolStripMenuItem) sender).Tag;
            var selectedRowIndices = regexPatternsDataGridView.SelectedCells
                .OfType<DataGridViewCell>()
                .Where(c => c.RowIndex >= 0)
                .Select(c => c.RowIndex)
                .Distinct();
            foreach (var index in selectedRowIndices)
            {
                var entry = regexPatternsDataGridView.Rows[index].DataBoundItem as RegexPatternEntry;
                if (entry != null)
                {
                    entry.IsEnabled = enable;
                }
            }
        }

        private void enableSelectedVariableEntriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var enable = (bool) ((ToolStripMenuItem) sender).Tag;
            var selectedRowIndices = variablesDataGridView.SelectedCells
                .OfType<DataGridViewCell>()
                .Where(c => c.RowIndex >= 0)
                .Select(c => c.RowIndex)
                .Distinct();
            foreach (var index in selectedRowIndices)
            {
                var entry = variablesDataGridView.Rows[index].DataBoundItem as Variable;
                if (entry != null)
                {
                    entry.IsEnabled = enable;
                }
            }
        }
    }
}