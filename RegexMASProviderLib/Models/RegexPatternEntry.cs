using System;
using System.Text.RegularExpressions;
using RegexMASProviderLib.Common;

namespace RegexMASProviderLib.Models
{
    public class RegexPatternEntry : ModelBase
    {
        public RegexPatternEntry()
        {
            Description = string.Empty;
            RegexPattern = string.Empty;
            ReplacePattern = "$0";
        }

        private bool _isEnabled;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        private string _description;

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _regexPattern;

        public string RegexPattern
        {
            get
            {
                return _regexPattern;
            }
            set
            {
                _regexPattern = value;
                if (string.IsNullOrEmpty(_regexPattern) || !IsValidPattern(_regexPattern))
                {
                    _errors["RegexPattern"] = "Invalid regex pattern";
                }
                else
                {
                    _errors.Remove("RegexPattern");
                }
                OnPropertyChanged("RegexPattern");
            }
        }

        private bool IsValidPattern(string pattern)
        {
            try
            {
                Regex.IsMatch("DUMMY", pattern);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private string _replacePattern;

        public string ReplacePattern
        {
            get
            {
                return _replacePattern;
            }
            set
            {
                _replacePattern = value;
                if (string.IsNullOrEmpty(_replacePattern) || !IsValidPattern(_replacePattern))
                {
                    _errors["ReplacePattern"] = "Invalid replace pattern";
                }
                else
                {
                    _errors.Remove("ReplacePattern");
                }
                OnPropertyChanged("ReplacePattern");
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
