using System.Windows.Forms;

namespace RegexMASProviderLib.View
{
    public class TabPageManager
    {
        private class TabPageInfo
        {
            public TabPage TabPage;
            public bool Visible;

            public TabPageInfo(TabPage page, bool v)
            {
                TabPage = page;
                Visible = v;
            }
        }

        private TabPageInfo[] _tabPageInfos = null;
        private TabControl _tabControl = null;

        public TabPageManager(TabControl crl)
        {
            _tabControl = crl;
            _tabPageInfos = new TabPageInfo[_tabControl.TabPages.Count];
            for (int i = 0; i < _tabControl.TabPages.Count; i++)
                _tabPageInfos[i] =
                    new TabPageInfo(_tabControl.TabPages[i], true);
        }

        /// <summary>
        /// Show/Hide TabPage
        /// </summary>
        /// <param name="index">Index of the TabPage to show/hide</param>
        /// <param name="v">True to show. False to hide</param>
        public void ChangeTabPageVisible(int index, bool v)
        {
            if (_tabPageInfos[index].Visible == v)
                return;

            _tabPageInfos[index].Visible = v;
            _tabControl.SuspendLayout();
            _tabControl.TabPages.Clear();
            for (int i = 0; i < _tabPageInfos.Length; i++)
            {
                if (_tabPageInfos[i].Visible)
                    _tabControl.TabPages.Add(_tabPageInfos[i].TabPage);
            }

            _tabControl.ResumeLayout();
        }
    }
}