using System.Collections.Generic;
using Capybara.EditorPlugin.RegexMASProvider.Models;

namespace Capybara.EditorPlugin.RegexMASProvider.View
{
    public class PopupWindowContent
    {
        public PopupWindowContent()
        {
            AutoSuggestEntries = new List<AutoSuggestEntry>();
        }

        public PopupWindowContent(IEnumerable<AutoSuggestEntry> autoSuggestEntries)
        {
            AutoSuggestEntries = new List<AutoSuggestEntry>(autoSuggestEntries);
        }

        public List<AutoSuggestEntry> AutoSuggestEntries { get; set; } 
    }
}
