using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

/// <summary>
/// Сравнивалка <see cref="ListViewItem"/>-ов
/// </summary>
public class ADDirectiveListViewComparer : IComparer<ListViewItem>
{
    #region Fields

    private readonly int columnIndex;
    private readonly int sortMultiplier;
    private const string pattern = "^\\s*(?<Year>\\d+)\\-(?<Number1>\\d+)\\-(?<Number2>\\d+)\\s+(§\\s+(?<ParagraphLetter>.+)?\\s*(?<ParagraphNumber>\\d+)?)?";

    #endregion

    #region Constructor

    /// <summary>
    /// Создает сравнивалку <see cref="ListViewItem"/>
    /// </summary>
    /// <param name="columnIndex"></param>
    /// <param name="sortMultiplier"></param>
    public ADDirectiveListViewComparer(int columnIndex, int sortMultiplier)
    {
        this.columnIndex = columnIndex;
        this.sortMultiplier = sortMultiplier;
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
    public int Compare(ListViewItem x, ListViewItem y)
    {
        if (x.Group.Name == "AF" && y.Group.Name == "AP")
            return 1;
        if (x.Group.Name == "AP" && y.Group.Name == "AF")
            return -1;
        if (columnIndex != 0)
            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);


        Match xMatch = Regex.Match(x.SubItems[columnIndex].Text, pattern);
        Match yMatch = Regex.Match(y.SubItems[columnIndex].Text, pattern);
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
            return (xYear == yYear) ? (xNumber1 == yNumber1) ? (xNumber2 == yNumber2) ? (xParagraphLetter == yParagraphLetter) ? (xParagraphNumber == yParagraphNumber) ? 0 : (xParagraphNumber - yParagraphNumber) : string.Compare(xParagraphLetter, yParagraphLetter) : sortMultiplier * (xNumber2 - yNumber2) : sortMultiplier * (xNumber1 - yNumber1) : sortMultiplier * (xYear - yYear);
        }
        if (xMatch.Success)
            return -1;
        if (yMatch.Success)
            return 1;
        return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
    }

    #endregion

    #endregion
}