using System;
using System.Windows.Forms;
using RegexMASProviderLib.Models;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.RegexMASPRovider_2017
{
    [ViewPart(
        Id = "RegexMatchAutoSuggestProviderViewPart",
        Name = "Plugin_Name",
        Description = "Plugin_Description",
        Icon = "RegexMASProvider_Icon"
    )]
    [ViewPartLayout(typeof(EditorController), Dock = DockType.Bottom)]
    class RegexMatchAutoSuggestProviderViewPartController : AbstractViewPartController
    {
        protected override Control GetContentControl()
        {
            return Control.Value;
        }

        protected override void Initialize()
        {
            
        }
        
        public RegexPattenEntries GetRegexPattenEntries()
        {
            return Control.Value.RegexPattenEntries;
        }

        public Variables GetVariables()
        {
            return Control.Value.Variables;
        }

        public ListChangeNotifier GetListChangeNotifier()
        {
            return Control.Value.ListChangeNotifier;
        }

        private static readonly Lazy<RegexMatchAutoSuggestProviderViewPartControl> Control = new Lazy<RegexMatchAutoSuggestProviderViewPartControl>(() => new RegexMatchAutoSuggestProviderViewPartControl());  
    }
}
