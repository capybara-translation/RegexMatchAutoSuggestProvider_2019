using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Capybara.EditorPlugin.RegexMASProvider.Models
{
    public class ListChangeNotifier
    {
        private List<BindingSource> _bindingSources;

        public List<BindingSource> BindingSources
        {
            set { _bindingSources = value; }
            get { return _bindingSources; }
        }

        public ListChangeNotifier()
        {
            BindingSources = new List<BindingSource>();
        }

        public void Start()
        {
            foreach (var source in BindingSources)
            {
                source.ListChanged += source_ListChanged;
            }
        }

        void source_ListChanged(object sender, ListChangedEventArgs e)
        {
            OnChanged(e);
        }

        public event EventHandler Changed;

        protected virtual void OnChanged(ListChangedEventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

    }
}
