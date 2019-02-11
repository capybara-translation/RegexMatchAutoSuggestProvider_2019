using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using RegexMASProviderLib.Common;
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

        private IEnumerable<XNode> NewLineToBr(string text)
        {
            return text.Select<char, XNode>(x =>
            {
                if (x == '\n')
                {
                    return new XElement(Xhtml.br);
                }
                return new XText(x.ToString());
            });
        }

        private IEnumerable<XNode> PrettifyCellElements(Match match, string text)
        {
            var nodes = new List<XNode>();
            if (match == null || !match.Success || string.IsNullOrEmpty(text))
            {
                return nodes;
            }

            var unmatchedLeftLength = match.Index > text.Length ? text.Length : match.Index;
            var unmatchedLeft = text.Substring(0, unmatchedLeftLength);

            var matched = match.Value;

            var unmatchedRightIndex = match.Index + match.Length > text.Length ? text.Length : match.Index + match.Length;
            var unmachedRight = text.Substring(unmatchedRightIndex);

            nodes.AddRange(NewLineToBr(unmatchedLeft));
            nodes.Add(new XElement(Xhtml.span, 
                new XAttribute("class", "matched"),
                NewLineToBr(matched)));
            nodes.AddRange(NewLineToBr(unmachedRight));

            return nodes;
        }

        private void lstEntries_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = ((ListBox) sender).SelectedItem as AutoSuggestEntry;
            if (item == null)
            {
                return;
            }

            var xhtml = XDocument.Parse(Properties.Resources.BaseHtml);
            var body = xhtml.Root.Element(Xhtml.body);

            var originalTable = new XElement(Xhtml.table);
            body.Add(originalTable);
            originalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "ORIGINAL SOURCE"),
                new XElement(Xhtml.td, PrettifyCellElements(item.ConcatenatedFindPatternMatch, item.OriginalSourceText))));
            originalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "ORIGINAL SEARCH"),
                new XElement(Xhtml.td, item.OriginalFindPattern)));
            originalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "EVALUATED SEARCH"),
                new XElement(Xhtml.td, item.ConcatenatedFindPattern)));

            var finalTable = new XElement(Xhtml.table);
            body.Add(finalTable);
            finalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "EVALUATED MATCH"),
                new XElement(Xhtml.td, NewLineToBr(item.NewSourceText))));
            finalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "FINAL SEARCH"),
                new XElement(Xhtml.td, item.EvaluatedFindPattern)));
            finalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "REPLACE"),
                new XElement(Xhtml.td, item.OriginalReplacePattern)));
            finalTable.Add(new XElement(Xhtml.tr,
                new XElement(Xhtml.th, "OUTPUT"),
                new XElement(Xhtml.td, NewLineToBr(item.AutoSuggestString))));

            DisplayHtml(xhtml);
        }


        private void DisplayHtml(XDocument xhtml)
        {
            browserMain.DocumentText = "0";
            browserMain.Document.OpenNew(true);
            browserMain.Document.Write(xhtml.ToString());
            browserMain.Refresh();
        }
    }
}