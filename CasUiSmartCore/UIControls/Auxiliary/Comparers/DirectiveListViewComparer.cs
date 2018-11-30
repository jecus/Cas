using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    internal class DirectiveListViewComparer : BaseListViewComparer// IComparer<ListViewItem>
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
        public DirectiveListViewComparer(int columnIndex, int sortMultiplier) : base(columnIndex,sortMultiplier)
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
            //if (x.Group.Name == "AF" && y.Group.Name == "AP")
            //    return 1;
            //if (x.Group.Name == "AP" && y.Group.Name == "AF")
            //    return -1;

            if (ColumnIndex == 0)
            {
                Match xMatch = Regex.Match(x.SubItems[ColumnIndex].Text, Pattern);
                Match yMatch = Regex.Match(y.SubItems[ColumnIndex].Text, Pattern);
                if (xMatch.Success && yMatch.Success)
                {
                    int xYear;
                    int xNumber1;
                    int xNumber2;
                    int.TryParse(xMatch.Groups["Year"].Value, out xYear);
                    int.TryParse(xMatch.Groups["Number1"].Value, out xNumber1);
                    int.TryParse(xMatch.Groups["Number2"].Value, out xNumber2);
                    string xParagraphLetter = "";
                    if (xMatch.Groups["ParagraphLetter"].Success)
                        xParagraphLetter = xMatch.Groups["ParagraphLetter"].Value;
                    int xParagraphNumber = 0;
                    if (xMatch.Groups["ParagraphNumber"].Success)
                        xParagraphNumber = int.Parse(xMatch.Groups["ParagraphNumber"].Value);
                    int yYear;
                    int yNumber1;
                    int yNumber2;
                    int.TryParse(yMatch.Groups["Year"].Value, out yYear);
                    int.TryParse(yMatch.Groups["Number1"].Value, out yNumber1);
                    int.TryParse(yMatch.Groups["Number2"].Value, out yNumber2);
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
            //if (_columnIndex == 5)
            //{
            //    //сортировка по статусу
            //    if (x.SubItems[_columnIndex].Text == "Open" && y.SubItems[_columnIndex].Text != "Open") return _sortMultiplier * -1;
            //    else if (y.SubItems[_columnIndex].Text == "Open" && x.SubItems[_columnIndex].Text != "Open") return _sortMultiplier * 1;
            //    else if (x.SubItems[_columnIndex].Text == "Repetative" && y.SubItems[_columnIndex].Text != "Repetative") return _sortMultiplier * -1;
            //    else if (y.SubItems[_columnIndex].Text == "Repetative" && x.SubItems[_columnIndex].Text != "Repetative") return _sortMultiplier * 1;
            //    else if (x.SubItems[_columnIndex].Text == "Closed" && y.SubItems[_columnIndex].Text != "Closed") return _sortMultiplier * -1;
            //    else if (y.SubItems[_columnIndex].Text == "Closed" && x.SubItems[_columnIndex].Text != "Closed") return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else if (_columnIndex == 6)
            //{
            //    //Сортировка по эффективной дате
            //    DateTime xDate, yDate;
            //    if (x.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)x.Tag).DirectiveCollection.Count != 0)
            //            xDate = ((PrimaryDirective)x.Tag).DirectiveCollection[0].Threshold.EffectiveDate;
            //        else xDate = new DateTime(1900, 1, 1);
            //    }
            //    else
            //    {
            //        if (((Directive)x.Tag).LastPerformance != null)
            //            xDate = ((Directive)x.Tag).Threshold.EffectiveDate;
            //        else xDate = new DateTime(1900, 1, 1);
            //    }
            //    if (y.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)y.Tag).DirectiveCollection.Count != 0)
            //            yDate = ((PrimaryDirective)y.Tag).DirectiveCollection[0].Threshold.EffectiveDate;
            //        else yDate = new DateTime(1900, 1, 1);
            //    }
            //    else
            //    {
            //        if (((Directive)y.Tag).LastPerformance != null)
            //            yDate = ((Directive)y.Tag).Threshold.EffectiveDate;
            //        else yDate = new DateTime(1900, 1, 1);
            //    }

            //    if (xDate > yDate) return _sortMultiplier * -1;
            //    else if (yDate > xDate) return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else if (_columnIndex == 10)
            //{
            //    //Сортировка по дате последнего выполнения
            //    DateTime xDate, yDate;
            //    if (x.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)x.Tag).DirectiveCollection.Count != 0 &&
            //            ((PrimaryDirective)x.Tag).DirectiveCollection[0].LastPerformance != null)
            //            xDate = ((PrimaryDirective)x.Tag).DirectiveCollection[0].LastPerformance.RecordDate;
            //        else xDate = new DateTime(1900,1,1);  
            //    }
            //    else
            //    {
            //        if (((Directive)x.Tag).LastPerformance != null) 
            //            xDate = ((Directive)x.Tag).LastPerformance.RecordDate;
            //        else xDate = new DateTime(1900, 1, 1);
            //    }
            //    if (y.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)y.Tag).DirectiveCollection.Count != 0 &&
            //            ((PrimaryDirective)y.Tag).DirectiveCollection[0].LastPerformance != null)
            //            yDate = ((PrimaryDirective)y.Tag).DirectiveCollection[0].LastPerformance.RecordDate;
            //        else yDate = new DateTime(1900, 1, 1);
            //    }
            //    else
            //    {
            //        if (((Directive)y.Tag).LastPerformance != null)
            //            yDate = ((Directive)y.Tag).LastPerformance.RecordDate;
            //        else yDate = new DateTime(1900, 1, 1);
            //    }
            //    if (xDate > yDate) return _sortMultiplier * -1;
            //    else if (yDate > xDate) return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else if (_columnIndex == 12)
            //{
            //    //сортировка по Kit Requiered
            //    if (x.SubItems[_columnIndex].Text == "Y" && y.SubItems[_columnIndex].Text != "Y") return _sortMultiplier * -1;
            //    else if (y.SubItems[_columnIndex].Text == "Y" && x.SubItems[_columnIndex].Text != "Y") return _sortMultiplier * 1;
            //    else if (x.SubItems[_columnIndex].Text == "N" && y.SubItems[_columnIndex].Text != "N") return _sortMultiplier * -1;
            //    else if (y.SubItems[_columnIndex].Text == "N" && x.SubItems[_columnIndex].Text != "N") return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else if (_columnIndex == 14)
            //{
            //    //Сортировка по MansHours
            //    double xDate, yDate;
            //    if (x.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)x.Tag).DirectiveCollection.Count != 0)
            //            xDate = ((PrimaryDirective) x.Tag).DirectiveCollection[0].ManHours;
            //        else
            //            xDate = 0;
            //    }
            //    else xDate = ((Directive)x.Tag).ManHours;

            //    if (y.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)y.Tag).DirectiveCollection.Count != 0)
            //            yDate = ((PrimaryDirective)y.Tag).DirectiveCollection[0].ManHours;
            //        else
            //            yDate = 0;
            //    }
            //    else yDate = ((Directive)y.Tag).ManHours;

            //    if (xDate > yDate) return _sortMultiplier * -1;
            //    else if (yDate > xDate) return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else if (_columnIndex == 15)
            //{
            //    //Сортировка по цене
            //    double xCost, yCost;
            //    if (x.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)x.Tag).DirectiveCollection.Count != 0)
            //            xCost = ((PrimaryDirective)x.Tag).DirectiveCollection[0].Cost;
            //        else
            //            xCost = 0;
            //    }
            //    else xCost = ((Directive)x.Tag).Cost;

            //    if (y.Tag is PrimaryDirective)
            //    {
            //        if (((PrimaryDirective)y.Tag).DirectiveCollection.Count != 0)
            //            yCost = ((PrimaryDirective)y.Tag).DirectiveCollection[0].Cost;
            //        else
            //            yCost = 0;
            //    }
            //    else yCost = ((Directive)y.Tag).Cost;

            //    if (xCost > yCost) return _sortMultiplier * -1;
            //    else if (yCost > xCost) return _sortMultiplier * 1;
            //    else return 0;
            //}
            //else return _sortMultiplier * string.Compare(x.SubItems[_columnIndex].Text, y.SubItems[_columnIndex].Text);
            return base.Compare(x, y);
        }

        #endregion

        #endregion
    }
}