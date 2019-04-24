using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    ///<summary>
    /// Базовый класс для сравнения 2-х эдементов списка
    ///</summary>
    public class BaseListViewComparer : IComparer<ListViewItem>
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
        public BaseListViewComparer(int columnIndex, int sortMultiplier)
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
        public virtual int Compare(ListViewItem x, ListViewItem y)
        {
            if (x.SubItems[ColumnIndex].Tag == null || y.SubItems[ColumnIndex].Tag == null)
            {
                return SortMultiplier * string.Compare(x.SubItems[ColumnIndex].Text, y.SubItems[ColumnIndex].Text);
            }
            if (x.SubItems[ColumnIndex].Tag is AtaChapter && y.SubItems[ColumnIndex].Tag is AtaChapter)
            {
                return ComparerMethods.ATAComparer(x.SubItems[ColumnIndex].Text, y.SubItems[ColumnIndex].Text)*
                       SortMultiplier;
            }
            if (x.SubItems[ColumnIndex].Tag is DirectiveStatus && y.SubItems[ColumnIndex].Tag is DirectiveStatus)
            {
                return ComparerMethods.DirectiveStatusComparer((DirectiveStatus)x.SubItems[ColumnIndex].Tag, 
                                                                (DirectiveStatus)y.SubItems[ColumnIndex].Tag) *
                       SortMultiplier;
            }
            if (x.SubItems[ColumnIndex].Tag is DateTime && y.SubItems[ColumnIndex].Tag is DateTime)
            {
                DateTime xValue = (DateTime)x.SubItems[ColumnIndex].Tag;
                DateTime yValue = (DateTime)y.SubItems[ColumnIndex].Tag;
                return SortMultiplier * DateTime.Compare(yValue,xValue);
            }
            if (x.SubItems[ColumnIndex].Tag is string && y.SubItems[ColumnIndex].Tag is string)
            {
	            int i, j;
	            if (int.TryParse(x.SubItems[ColumnIndex].Text, out i) && int.TryParse(y.SubItems[ColumnIndex].Text, out j))
	            {
					return SortMultiplier * (i - j);
				}

                return SortMultiplier * string.Compare(x.SubItems[ColumnIndex].Text, y.SubItems[ColumnIndex].Text);
            }
            if (x.SubItems[ColumnIndex].Tag is int && y.SubItems[ColumnIndex].Tag is int)
            {
                int xValue = (int) x.SubItems[ColumnIndex].Tag;
                int yValue = (int) y.SubItems[ColumnIndex].Tag;
                return SortMultiplier*(yValue - xValue);
            }
            if (x.SubItems[ColumnIndex].Tag is double && y.SubItems[ColumnIndex].Tag is double)
            {
                double xValue = (double)x.SubItems[ColumnIndex].Tag;
                double yValue = (double)y.SubItems[ColumnIndex].Tag;
                return SortMultiplier * (int)(yValue - xValue);
            }
            if(x.SubItems[ColumnIndex].Tag as IComparable != null && (x.SubItems[ColumnIndex].Tag.GetType().Equals(y.SubItems[ColumnIndex].Tag.GetType())))
            {
	            try
	            {
		            return SortMultiplier * ((IComparable)x.SubItems[ColumnIndex].Tag).CompareTo(y.SubItems[ColumnIndex].Tag);
	            }
	            catch
	            {
	            }
            }
            return SortMultiplier * string.Compare(x.SubItems[ColumnIndex].Text, y.SubItems[ColumnIndex].Text);
        }

        #endregion

        #endregion
    }
}
