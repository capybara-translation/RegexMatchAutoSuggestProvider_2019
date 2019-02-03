using System.Collections.Generic;

namespace Capybara.EditorPlugin.RegexMASProvider.Models
{
    public class PopupWindowContent
    {
        public PopupWindowContent()
        {
            Suggestions = new List<string>();
        }
        public List<string> Suggestions { get; set; } 
    }
}
