using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using Microsoft.Office.Interop.Excel;
using SmartCore.CAA.Check;
using SmartCore.CAA.PEL;
using SmartCore.Entities.Dictionaries;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
	public class DirectiveGridViewDataRowInfoComparer : GridViewDataRowInfoComparer
	{
		#region Fields
		private const string Pattern = "^\\s*(?<Year>\\d+)\\-(?<Number1>\\d+)\\-(?<Number2>\\d+)?";

		#endregion

		#region Constructor

		/// <summary>
		/// Создает сравнивалку <see cref="ListViewItem"/>
		/// </summary>
		/// <param name="columnIndex"></param>
		/// <param name="sortMultiplier"></param>
		public DirectiveGridViewDataRowInfoComparer(int columnIndex, int sortMultiplier) : base(columnIndex, sortMultiplier)
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
		public override int Compare(GridViewRowInfo x, GridViewRowInfo y)
		{
			var first = ((CustomCell)x.Cells[ColumnIndex].Tag);
			var second = ((CustomCell)y.Cells[ColumnIndex].Tag);

			if (ColumnIndex == 0)
			{
				Match xMatch = Regex.Match(first.Text, Pattern);
				Match yMatch = Regex.Match(second.Text, Pattern);
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
				return SortMultiplier * string.Compare(first.Text, second.Text);
			}




			if (first.Tag == null || second.Tag == null)
			{
				return SortMultiplier * string.Compare(first.Text, second.Text);
			}
			if (first.Tag is AtaChapter && second.Tag is AtaChapter)
			{
				return ComparerMethods.ATAComparer(first.Text, second.Text) *
					   SortMultiplier;
			}
			if (first.Tag is DirectiveStatus && second.Tag is DirectiveStatus)
			{
				return ComparerMethods.DirectiveStatusComparer((DirectiveStatus)first.Tag,
																(DirectiveStatus)second.Tag) *
					   SortMultiplier;
			}
			if (first.Tag is DateTime && second.Tag is DateTime)
			{
				DateTime xValue = (DateTime)first.Tag;
				DateTime yValue = (DateTime)second.Tag;
				return SortMultiplier * DateTime.Compare(yValue, xValue);
			}
			if (first.Tag is string && second.Tag is string)
			{
				int i, j;
				if (int.TryParse(first.Text, out i) && int.TryParse(second.Text, out j))
				{
					return SortMultiplier * (i - j);
				}

				return SortMultiplier * string.Compare(first.Text, second.Text);
			}
			if (first.Tag is int && second.Tag is int)
			{
				int xValue = (int)first.Tag;
				int yValue = (int)second.Tag;
				return SortMultiplier * (yValue - xValue);
			}
			if (first.Tag is double && second.Tag is double)
			{
				double xValue = (double)first.Tag;
				double yValue = (double)second.Tag;
				return SortMultiplier * (int)(yValue - xValue);
			}
			if (first.Tag as IComparable != null && (first.Tag.GetType().Equals(second.Tag.GetType())))
			{
				try
				{
					return SortMultiplier * ((IComparable)first.Tag).CompareTo(second.Tag);
				}
				catch
				{
				}
			}
			return SortMultiplier * string.Compare(first.Text, second.Text);



			return base.Compare(x, y);
		}

		#endregion

		#endregion
	}


    public class GroupComparer : IComparer<Group<GridViewRowInfo>>
    {
        public int Compare(Group<GridViewRowInfo> x, Group<GridViewRowInfo> y)
        {
            var xx = x.GetItems().FirstOrDefault()?.Tag;
            var yy = y.GetItems().FirstOrDefault()?.Tag;

			if (xx != null && yy != null)
            {
                var xxx = xx as CheckLists;
                var yyy = yy as CheckLists;

                var xParts = xxx.Group;
                var yParts = yyy.Group;

                var partsLength = Math.Max(xParts.Length, yParts.Length);
                if (partsLength > 0)
                {
                    for (var i = 0; i < partsLength; i++)
                    {
                        if (xParts.Length <= i) return -1;// 4.2 < 4.2.x
                        if (yParts.Length <= i) return 1;

                        var xPart = xParts[i];
                        var yPart = yParts[i];

                        if (string.IsNullOrEmpty(xPart)) xPart = "0";// 5..2->5.0.2
                        if (string.IsNullOrEmpty(yPart)) yPart = "0";

                        if (!int.TryParse(xPart, out var xInt) || !int.TryParse(yPart, out var yInt))
                        {
                            // 3.a.45 compare part as string
                            var abcCompare = xPart.CompareTo(yPart);
                            if (abcCompare != 0)
                                return -1 * abcCompare;
                            continue;
                        }

                        if (xInt != yInt) return xInt < yInt ? -1 : 1;
                    }
                    return 0;
                }
            }

            return -1;
            //return ((object[])x.Key)[0].ToString().CompareTo(((object[])y.Key)[0].ToString());
        }
    }

	public class CheckListsGroupComparer : IComparer<Group<GridViewRowInfo>>
	{
        

        public int SortMultiplier { get; set; }

        public virtual int Compare(Group<GridViewRowInfo> x, Group<GridViewRowInfo> y)
        {
            var xx = $"{((object[])x.Key)[0]}|{((object[])x.Key)[2]}|{((object[])x.Key)[4]}";
            var yy = $"{((object[])y.Key)[0]}|{((object[])y.Key)[2]}|{((object[])y.Key)[4]}";

			var a = Regex.Replace(xx, @"\s+", " "); ;
            var b = Regex.Replace(yy, @"\s+", " "); ;

            var xParts = a.Split('|')
                .SelectMany(i => i.Split(' '))
                .SelectMany(i => i.Split('.'))
                .ToArray();
            var yParts = b.Split('|')
                .SelectMany(i => i.Split(' '))
                .SelectMany(i => i.Split('.'))
                .ToArray();

            var partsLength = Math.Max(xParts.Length, yParts.Length);
            if (partsLength > 0)
            {
                for (var i = 0; i < partsLength; i++)
                {
                    if (xParts.Length <= i) return -1;// 4.2 < 4.2.x
                    if (yParts.Length <= i) return 1;

                    var xPart = xParts[i];
                    var yPart = yParts[i];

                    if (string.IsNullOrEmpty(xPart)) xPart = "0";// 5..2->5.0.2
                    if (string.IsNullOrEmpty(yPart)) yPart = "0";

                    if (!int.TryParse(xPart, out var xInt) || !int.TryParse(yPart, out var yInt))
                    {
                        // 3.a.45 compare part as string
                        var abcCompare = xPart.CompareTo(yPart);
                        if (abcCompare != 0)
                            return SortMultiplier * abcCompare;
                        continue;
                    }

                    if (xInt != yInt) return xInt < yInt ? -1 : 1;
                }
                return 0;
            }
            // compare as string
            return SortMultiplier * xx.CompareTo(yy);
		}
	}



	public class CheckListsComparer : IComparer<GridViewRowInfo>
    {
        public CheckListsComparer(int sortMultiplier)
        {
			SortMultiplier = sortMultiplier;
		}

        public int SortMultiplier { get; set; }

        public virtual int Compare(GridViewRowInfo x, GridViewRowInfo y)
        {
	        CheckLists xx = null;
	        CheckLists yy = null;
	        if (x.Tag is CheckLists)
		        xx = x.Tag as CheckLists;
	        if (y.Tag is CheckLists)
		        yy = y.Tag as CheckLists;
	        
	        
	        if (x.Tag is AuditPelRecord)
		        xx = (x.Tag as AuditPelRecord).CheckList;
	        if (y.Tag is AuditPelRecord)
		        yy = (y.Tag as AuditPelRecord).CheckList;

	        if (xx == null || y is null)
		        return 0;

	        if(xx.Settings == null || yy.Settings == null)
		        return 0;
	        
			var a = Regex.Replace($"{xx.SectionNumber}|{xx.PartNumber}|{xx.SubPartNumber}|{xx.ItemNumber}", @"\s+", " "); ;
            var b = Regex.Replace($"{yy.SectionNumber}|{yy.PartNumber}|{yy.SubPartNumber}|{yy.ItemNumber}", @"\s+", " "); ;

			var xParts = a.Split('|')
                .SelectMany(i => i.Split(' '))
                .SelectMany(i => i.Split('.'))
                .ToArray();
            var yParts = b.Split('|')
                .SelectMany(i => i.Split(' '))
				.SelectMany(i => i.Split('.'))
                .ToArray();

			xParts[xParts.Length - 1] = Regex.Replace(xParts[xParts.Length - 1], "[^0-9.]", "");
            yParts[yParts.Length - 1] = Regex.Replace(yParts[yParts.Length - 1], "[^0-9.]", "");



			var partsLength = Math.Max(xParts.Length, yParts.Length);
            if (partsLength > 0)
            {
                for (var i = 0; i < partsLength; i++)
                {
                    if (xParts.Length <= i) return -1;// 4.2 < 4.2.x
                    if (yParts.Length <= i) return 1;

                    var xPart = xParts[i];
                    var yPart = yParts[i];

                    if (string.IsNullOrEmpty(xPart)) xPart = "0";// 5..2->5.0.2
                    if (string.IsNullOrEmpty(yPart)) yPart = "0";

                    if (!int.TryParse(xPart, out var xInt) || !int.TryParse(yPart, out var yInt))
                    {
                        // 3.a.45 compare part as string
                        var abcCompare = xPart.CompareTo(yPart);
                        if (abcCompare != 0)
                            return SortMultiplier * abcCompare;
                        continue;
                    }

                    if (xInt != yInt) return SortMultiplier *(xInt < yInt ? -1 : 1);
                }
                return SortMultiplier * -1;
                //return  0;
            }
            // compare as string
            return SortMultiplier * xx.CompareTo(yy);
        }
    }


	public class GridViewDataRowInfoComparer : IComparer<GridViewRowInfo>
	{
		#region Fields

		protected readonly int ColumnIndex;
		protected readonly int SortMultiplier;
		#endregion

		#region Constructor

		/// <summary>
		/// Создает сравнивалку <see cref="ListViewItem"/>
		/// </summary>
		/// <param name="columnIndex"></param>
		/// <param name="sortMultiplier"></param>
		public GridViewDataRowInfoComparer(int columnIndex, int sortMultiplier)
		{
			ColumnIndex = columnIndex;
			SortMultiplier = sortMultiplier;
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
		public virtual int Compare(GridViewRowInfo x, GridViewRowInfo y)
		{
			var first = ((CustomCell)x.Cells[ColumnIndex].Tag);
			var second = ((CustomCell)y.Cells[ColumnIndex].Tag);

			if (first.Tag == null || second.Tag == null)
			{
				return SortMultiplier * string.Compare(first.Text, second.Text);
			}
			if (first.Tag is AtaChapter && second.Tag is AtaChapter)
			{
				return ComparerMethods.ATAComparer(first.Text, second.Text) *
					   SortMultiplier;
			}
			if (first.Tag is DirectiveStatus && second.Tag is DirectiveStatus)
			{
				return ComparerMethods.DirectiveStatusComparer((DirectiveStatus)first.Tag,
																(DirectiveStatus)second.Tag) *
					   SortMultiplier;
			}
			if (first.Tag is DateTime && second.Tag is DateTime)
			{
				DateTime xValue = (DateTime)first.Tag;
				DateTime yValue = (DateTime)second.Tag;
				return SortMultiplier * DateTime.Compare(yValue, xValue);
			}
			if (first.Tag is string && second.Tag is string)
			{
				int i, j;
				if (int.TryParse(first.Text, out i) && int.TryParse(second.Text, out j))
				{
					return SortMultiplier * (i - j);
				}

				return SortMultiplier * string.Compare(first.Text, second.Text);
			}
			if (first.Tag is int && second.Tag is int)
			{
				int xValue = (int)first.Tag;
				int yValue = (int)second.Tag;
				return SortMultiplier * (yValue - xValue);
			}
			if (first.Tag is double && second.Tag is double)
			{
				double xValue = (double)first.Tag;
				double yValue = (double)second.Tag;
				return SortMultiplier * (int)(yValue - xValue);
			}
			if (first.Tag as IComparable != null && (first.Tag.GetType().Equals(second.Tag.GetType())))
			{
				try
				{
					return SortMultiplier * ((IComparable)first.Tag).CompareTo(second.Tag);
				}
				catch
				{
				}
			}
			return SortMultiplier * string.Compare(first.Text, second.Text);
		}

		#endregion

		#endregion
	}
}