using System;
using System.ComponentModel;
using System.Windows.Forms;
using Capybara.EditorPlugin.RegexMASProvider.Models;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.RegexMASProvider
{
    public partial class RegexMatchAutoSuggestProviderViewPartControl : UserControl
    {
        private RegexPattenEntries _regexPatternEntries = new RegexPattenEntries();
        private Variables _variables = new Variables();
        private ListChangeNotifier _listChangeNotifier = new ListChangeNotifier();

        public RegexPattenEntries RegexPattenEntries
        {
            get { return _regexPatternEntries; }
        }

        public Variables Variables
        {
            get { return _variables; }
        }

        public ListChangeNotifier ListChangeNotifier
        {
            get { return _listChangeNotifier; }
        }

        public RegexMatchAutoSuggestProviderViewPartControl()
        {
            InitializeComponent();
            InitializeDataBindings();
            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            editorController.Closed += (sender, args) =>
            {
                _regexPatternEntries.Save();
                _variables.Save();
            };
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
    }
}