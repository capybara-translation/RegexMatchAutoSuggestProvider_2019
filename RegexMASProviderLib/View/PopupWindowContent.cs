using System.Collections.Generic;
using RegexMASProviderLib.Models;

namespace RegexMASProviderLib.View
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
