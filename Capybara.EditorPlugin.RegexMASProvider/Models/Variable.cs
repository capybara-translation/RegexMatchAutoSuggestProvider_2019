using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using Capybara.EditorPlugin.RegexMASProvider.Common;

namespace Capybara.EditorPlugin.RegexMASProvider.Models
{
    public class Variable : ModelBase
    {
        public Variable()
        {
            Name = string.Empty;
            TranslationPairs = new BindingList<TranslationPair>();
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (string.IsNullOrEmpty(_name))
                {
                    _errors["Name"] = "Cannot be empty.";
                }
                else if (Regex.IsMatch(_name, @"[\p{P}\p{S}-[_]]|[\p{Z}\t\r\n\v\f]|\p{Cc}"))
                {
                    _errors["Name"] = "Contains invalid characters.";
                }
                else if (Regex.IsMatch(_name, @"^[0-9]"))
                {
                    _errors["Name"] = "Cannot start with a number.";
                }
                else
                {
                    _errors.Remove("Name");
                }
                OnPropertyChanged("Name");
            }
        }

        private BindingList<TranslationPair> _translationPairs;

        public BindingList<TranslationPair> TranslationPairs
        {
            get { return _translationPairs; }
            set
            {
                _translationPairs = value;
                OnPropertyChanged("TranslationPairs");
            }
        }

        public override string Error
        {
            get
            {
                var total = TranslationPairs.Count;
                if (total != TranslationPairs.Select(e => e.Source).Distinct().Count())
                {
                    return "Duplicate items in Source.";
                }
                return null;
            }
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
