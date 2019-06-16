using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.NewGrid;
using SmartCore.Entities.Dictionaries;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
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