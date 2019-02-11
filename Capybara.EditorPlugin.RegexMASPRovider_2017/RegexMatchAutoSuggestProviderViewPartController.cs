using System;
using System.Reflection;
using System.Windows.Forms;
using RegexMASProviderLib.Common;
using RegexMASProviderLib.Models;
using RegexMASProviderLib.View;
using Sdl.Desktop.IntegrationApi;
using Sdl.Desktop.IntegrationApi.Extensions;
using Sdl.TranslationStudioAutomation.IntegrationApi;

namespace Capybara.EditorPlugin.RegexMASProvider_2017
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
            var executingAssembly = Assembly.GetExecutingAssembly();

            // Load regex entries
            var regexFileExtension = ".settings.xml";
            var regexFilePath = Utils.GetSettingsPath(regexFileExtension, executingAssembly);
            _regexPatternEntries = new RegexPatternEntries();
            _regexPatternEntries.Load(regexFilePath);

            // Load variable entries
            var variableFileExtension = ".variables.xml";
            var variableFilePath = Utils.GetSettingsPath(variableFileExtension, executingAssembly);
            _variables = new Variables();
            _variables.Load(variableFilePath);
            _listChangeNotifier = new ListChangeNotifier();
            Control.Value.Initialize(_regexPatternEntries, _variables, _listChangeNotifier);


            var editorController = SdlTradosStudio.Application.GetController<EditorController>();
            editorController.Closed += (sender, args) =>
            {
                _regexPatternEntries.Save(regexFilePath);
                _variables.Save(variableFilePath);
            };
        }


        private RegexPatternEntries _regexPatternEntries;

        public RegexPatternEntries RegexPatternEntries
        {
            get { return _regexPatternEntries; }
        }

        private Variables _variables;

        public Variables Variables
        {
            get { return _variables; }
        }

        private ListChangeNotifier _listChangeNotifier;

        public ListChangeNotifier ListChangeNotifier
        {
            get { return _listChangeNotifier; }
        }


        private static readonly Lazy<RegexDataGridView> Control = 
            new Lazy<RegexDataGridView>(() =>
        {
            return new RegexDataGridView();
        });  
    }
}
