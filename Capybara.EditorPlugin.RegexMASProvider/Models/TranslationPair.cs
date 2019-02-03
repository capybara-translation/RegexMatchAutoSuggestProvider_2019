using Capybara.EditorPlugin.RegexMASProvider.Common;

namespace Capybara.EditorPlugin.RegexMASProvider.Models
{
    public class TranslationPair : ModelBase
    {
        public TranslationPair()
        {
            Source = string.Empty;
            Target = string.Empty;
        }

        private string _source;

        public string Source
        {
            get { return _source; }
            set
            {
                _source = value;
                if (string.IsNullOrEmpty(_source))
                {
                    _errors["Source"] = "Invalid source text";
                }
                else
                {
                    _errors.Remove("Source");
                }
                OnPropertyChanged("Source");
            }
        }

        private string _target;

        public string Target
        {
            get { return _target; }
            set
            {
                _target = value;
                if (string.IsNullOrEmpty(_target))
                {
                    _errors["Target"] = "Invalid target text";
                }
                else
                {
                    _errors.Remove("Target");
                }
                OnPropertyChanged("Target");
            }
        }

        public override string Error
        {
            get { return null; }
        }

        public bool HasErrors
        {
            get
            {
                return _errors.Count != 0;
            }
        }
    }
}
