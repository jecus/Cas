using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessing
{
    /// <summary>
    /// Represents class for pattern search
    /// </summary>
    /// 
    /// 
    public class Pattern
    {
        #region Fields

        #region private bool isGreedy
        /// <summary>
        /// Defines greediness of search
        /// </summary>
        private bool _isGreedy;
        #endregion

        #region private string _searchPattern
        /// <summary>
        /// Pattern to match
        /// </summary>
        private string _searchPattern;
        #endregion

        #region private bool _caseSensitive
        /// <summary>
        /// Case sensitivity of Pattern [:|||:]
        /// </summary>
        private bool _caseSensitive = true;
        #endregion

        #endregion

        #region Constructors

        #region public Pattern(string searchPattern, bool isGreedy, bool caseSensitive)

        /// <summary>
        /// Creates new instance of Pattern
        /// </summary>
        /// <param name="searchPattern">Pattern to match</param>
        /// <param name="isGreedy">Defines greediness of search</param>
        /// <param name="caseSensitive"></param>
        public Pattern(string searchPattern, bool isGreedy, bool caseSensitive)
        {
            _isGreedy = isGreedy;
            _searchPattern = searchPattern;
            _caseSensitive = caseSensitive;
        }
        #endregion

        #endregion

        #region Properties

        #region public bool IsGreedy
        /// <summary>
        /// Defines greediness of search
        /// </summary>
        public bool IsGreedy
        {
            get { return _isGreedy; }
            set { _isGreedy = value; }
        }
        #endregion

        #region public string SearchPattern
        /// <summary>
        /// Pattern to match
        /// </summary>
        public string SearchPattern
        {
            get { return _searchPattern; }
            set { _searchPattern = value; }
        }
        #endregion

        #region public bool CaseSensitive
        /// <summary>
        /// Case sensitivity of Pattern [:|||:]
        /// </summary>
        public bool CaseSensitive
        {
            get { return _caseSensitive; }
            set { _caseSensitive = value; }
        }
        #endregion

        #endregion

        #region Methods

        #region private string ConvertPattern(string value)
        /// <summary>
        /// Shields searchPattern and converts it to canonic regular expression
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ConvertPattern(string value)
        {
            StringBuilder result = new StringBuilder(value);

            result = result.Replace("(", "\\(");
            result = result.Replace(")", "\\)");
            result = result.Replace("[", "\\[");
            result = result.Replace("]", "\\]");
            result = result.Replace("<", "\\<");
            result = result.Replace(">", "\\>");
            result = result.Replace(".", "[.]");

            result = result.Replace("?", "[-A-Za-zР-пр-џ0-9.]?");
            result = result.Replace("*", _isGreedy ? "[A-Za-zР-пр-џ0-9]*" : "[A-Za-zР-пр-џ0-9]*?");
            result = result.Replace("+", _isGreedy ? "[A-Za-zР-пр-џ0-9]+" : "[A-Za-zР-пр-џ0-9]+?");

            return result.ToString();
        }
        #endregion

        #region private Regex GetRegex()
        private Regex GetRegex()
        {
            RegexOptions options = _caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase;
            Regex result = new Regex(ConvertPattern(_searchPattern), options);
            return result;
        }
        #endregion

        #region public Match Match(string input)
        /// <summary>
        /// Searches the specified input string for an occurence of a pattern
        /// </summary>
        /// <param name="input">Search destination</param>
        /// <returns></returns>
        public Match Match(string input)
        {
            Regex regex = GetRegex();
            Match result = regex.Match(input);
            return result;
        }
        #endregion

        #region public MatchCollection Matches(string input)
        /// <summary>
        /// Searches the specified input string for all occurences of a pattern
        /// </summary>
        /// <param name="input">Search destination</param>
        /// <returns></returns>
        public MatchCollection Matches(string input)
        {
            Regex regex = GetRegex();
            MatchCollection result = regex.Matches(input);
            return result;
        }
        #endregion

        #region public bool IsMatch(string input)
        public bool IsMatch(string input)
        {
            Regex regex = GetRegex();
            return regex.IsMatch(input);
        }
        #endregion

        #endregion
    }
}
