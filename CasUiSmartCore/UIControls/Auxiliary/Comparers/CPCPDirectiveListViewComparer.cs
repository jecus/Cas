using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// Сравнивалка <see cref="ListViewItem"/>-ов
    /// </summary>
    public class CPCPDirectiveListViewComparer : BaseListViewComparer
    {
        #region Fields

        // private const string pattern = "^\\s*(?<Year>\\d+)\\-(?<Number1>\\d+)\\-(?<Number2>\\d+)\\s+(§\\s+(?<ParagraphLetter>.+)?\\s*(?<ParagraphNumber>\\d+)?)?";
        private const string Pattern = "^\\s*(?<Year>\\d+)\\-(?<Number1>\\d+)\\-(?<Number2>\\d+)?";

        #endregion

        #region Constructor

        /// <summary>
        /// Создает сравнивалку <see cref="ListViewItem"/>
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="sortMultiplier"></param>
        public CPCPDirectiveListViewComparer(int columnIndex, int sortMultiplier) : base(columnIndex, sortMultiplier)
        {
        }

        #endregion

        #region Methods

        #region IComparer<ListViewItem> Members

        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public override int Compare(ListViewItem x, ListViewItem y)
        {
            switch (ColumnIndex)
            {
                case 0:
                    { 
                        Match xMatch = Regex.Match(x.SubItems[ColumnIndex].Text, Pattern);
                        Match yMatch = Regex.Match(y.SubItems[ColumnIndex].Text, Pattern);
                        if (xMatch.Success && yMatch.Success)
                        {
                            int xYear = int.Parse(xMatch.Groups["Year"].Value);
                            int xNumber1 = int.Parse(xMatch.Groups["Number1"].Value);
                            int xNumber2 = int.Parse(xMatch.Groups["Number2"].Value);
                            string xParagraphLetter = "";
                            if (xMatch.Groups["ParagraphLetter"].Success)
                                xParagraphLetter = xMatch.Groups["ParagraphLetter"].Value;
                            int xParagraphNumber = 0;
                            if (xMatch.Groups["ParagraphNumber"].Success)
                                xParagraphNumber = int.Parse(xMatch.Groups["ParagraphNumber"].Value);
                            int yYear = int.Parse(yMatch.Groups["Year"].Value);
                            int yNumber1 = int.Parse(yMatch.Groups["Number1"].Value);
                            int yNumber2 = int.Parse(yMatch.Groups["Number2"].Value);
                            string yParagraphLetter = "";
                            if (yMatch.Groups["ParagraphLetter"].Success)
                                yParagraphLetter = yMatch.Groups["ParagraphLetter"].Value;
                            int yParagraphNumber = 0;
                            if (yMatch.Groups["ParagraphNumber"].Success)
                                yParagraphNumber = int.Parse(yMatch.Groups["ParagraphNumber"].Value);

                            if (xYear < 100)
                                xYear += 1900;
                            if (yYear < 100)
                                yYear += 1900;
                            return (xYear == yYear) ? (xNumber1 == yNumber1) ? (xNumber2 == yNumber2) ? (xParagraphLetter == yParagraphLetter) ? (xParagraphNumber == yParagraphNumber) ? 0 : (xParagraphNumber - yParagraphNumber) : string.Compare(xParagraphLetter, yParagraphLetter) : SortMultiplier * (xNumber2 - yNumber2) : SortMultiplier * (xNumber1 - yNumber1) : SortMultiplier * (xYear - yYear);
                        }
                        if (xMatch.Success)
                            return -1;
                        if (yMatch.Success)
                            return 1;
                        return SortMultiplier * string.Compare(x.SubItems[ColumnIndex].Text, y.SubItems[ColumnIndex].Text);
                    }

            }
            return base.Compare(x, y);
        }

        #endregion

        #endregion
    }
}