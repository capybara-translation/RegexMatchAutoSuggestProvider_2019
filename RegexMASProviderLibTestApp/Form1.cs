using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegexMASProviderLib.Models;
using RegexMASProviderLib.View;

namespace RegexMASProviderLibTestApp
{
    public partial class Form1 : Form
    {
        private RegexPatternEntries _regexPatternEntries;
        private Variables _variables;
        private ListChangeNotifier _listChangeNotifier;

        public string RegexFile
        {
            get { return @"..\..\TestFiles\regex.xml"; }
        }

        public string VariableFile
        {
            get { return @"..\..\TestFiles\variables.xml"; }
        }

        public Form1()
        {
            InitializeComponent();
            _regexPatternEntries = new RegexPatternEntries();
            _regexPatternEntries.Load(RegexFile);
            _variables = new Variables();
            _variables.Load(VariableFile);
            _listChangeNotifier = new ListChangeNotifier();
            regexDgv.Initialize(_regexPatternEntries, _variables, _listChangeNotifier);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _regexPatternEntries.Save(RegexFile);
            _variables.Save(VariableFile);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var sourceText = txtSource.Text;
            if (string.IsNullOrEmpty(sourceText))
            {
                return;
            }

            var autoSuggestEntries = _regexPatternEntries.GetAutoSuggestEntries(sourceText, _variables);
            var popupContent = new PopupWindowContent(autoSuggestEntries);
            popupWindow.SetContent(popupContent);

        }

        private void btnShowRegexTester_Click(object sender, EventArgs e)
        {
            regexDgv.ShowRegexTester = !regexDgv.ShowRegexTester;
        }
    }
}
