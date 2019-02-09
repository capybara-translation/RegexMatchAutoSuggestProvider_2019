using System.Text.RegularExpressions;

namespace RegexMASProviderLib.Models
{
    public class AutoSuggestEntry
    {
        public override string ToString()
        {
            return AutoSuggestString;
        }

        /// <summary>
        /// Original entire source text
        /// </summary>
        public string OriginalSourceText { get; set; }

        /// <summary>
        /// Original (user-input) regex search pattern
        /// </summary>
        public string OriginalFindPattern { get; set; }

        /// <summary>
        /// Original (user-input) regex replace pattern
        /// </summary>
        public string OriginalReplacePattern { get; set; }

        /// <summary>
        /// Regex search pattern whose variables are each uniquely numbered
        /// </summary>
        public string NumberedFindPattern { get; set; }

        /// <summary>
        /// Regex search pattern whose variables are evaluated to pipe-joined patterns
        /// </summary>
        public string ConcatenatedFindPattern { get; set; }

        /// <summary>
        /// Match object for ConcatenatedFindPattern
        /// </summary>
        public Match ConcatenatedFindPatternMatch { get; set; }

        /// <summary>
        /// Final search pattern constructed from NumberedFindPattern whose variables are replaced with actual values
        /// </summary>
        public string EvaluatedFindPattern { get; set; }

        /// <summary>
        /// Match object for EvaluatedFindPattern
        /// </summary>
        public Match EvaluatedFindPatternMatch { get; set; }

        /// <summary>
        /// Entire source text in which the matched parts of variables are replaced with actual values
        /// </summary>
        public string NewSourceText { get; set; }

        /// <summary>
        /// Final AutoSuggest string
        /// </summary>
        public string AutoSuggestString { get; set; }
    }
}