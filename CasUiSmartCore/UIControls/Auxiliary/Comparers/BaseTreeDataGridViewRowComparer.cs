using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary.TreeDataGridView;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    ///<summary>
    /// Базовый класс для сравнения 2-х эдементов списка
    ///</summary>
    public class BaseTreeDataGridViewRowComparer : IComparer<TreeDataGridViewRow>
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
        public BaseTreeDataGridViewRowComparer(int columnIndex, int sortMultiplier)
        {
            ColumnIndex = columnIndex;
            SortMultiplier = sortMultiplier;
        }

        #endregion

        #region Methods

        #region IComparer<TreeDataGridViewRow> Members

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
        public virtual int Compare(TreeDataGridViewRow x, TreeDataGridViewRow y)
        {
            if (x.Cells[ColumnIndex].Tag == null || y.Cells[ColumnIndex].Tag == null)
            {
                string xValueString = x.Cells[ColumnIndex].Value != null ? x.Cells[ColumnIndex].Value.ToString() : "";
                string yValueString = y.Cells[ColumnIndex].Value != null ? y.Cells[ColumnIndex].Value.ToString() : "";
                return SortMultiplier * string.Compare(xValueString, yValueString);
            }
            if (x.Cells[ColumnIndex].Tag is AtaChapter && y.Cells[ColumnIndex].Tag is AtaChapter)
            {
                string xValueString = x.Cells[ColumnIndex].Value != null ? x.Cells[ColumnIndex].Value.ToString() : "";
                string yValueString = y.Cells[ColumnIndex].Value != null ? y.Cells[ColumnIndex].Value.ToString() : "";
                return ComparerMethods.ATAComparer(xValueString, yValueString) * SortMultiplier;
            }
            if (x.Cells[ColumnIndex].Tag is DirectiveStatus && y.Cells[ColumnIndex].Tag is DirectiveStatus)
            {
                return ComparerMethods.DirectiveStatusComparer((DirectiveStatus)x.Cells[ColumnIndex].Tag, 
                                                               (DirectiveStatus)y.Cells[ColumnIndex].Tag) *
                       SortMultiplier;
            }
            if (x.Cells[ColumnIndex].Tag is DateTime && y.Cells[ColumnIndex].Tag is DateTime)
            {
                DateTime xValue = (DateTime)x.Cells[ColumnIndex].Tag;
                DateTime yValue = (DateTime)y.Cells[ColumnIndex].Tag;
                return SortMultiplier * DateTime.Compare(yValue,xValue);
            }
            if (x.Cells[ColumnIndex].Tag is string && y.Cells[ColumnIndex].Tag is string)
            {
                return SortMultiplier * string.Compare((string)x.Cells[ColumnIndex].Tag, (string)y.Cells[ColumnIndex].Tag);
            }
            if (x.Cells[ColumnIndex].Tag is int && y.Cells[ColumnIndex].Tag is int)
            {
                int xValue = (int) x.Cells[ColumnIndex].Tag;
                int yValue = (int) y.Cells[ColumnIndex].Tag;
                return SortMultiplier*(yValue - xValue);
            }
            if (x.Cells[ColumnIndex].Tag is double && y.Cells[ColumnIndex].Tag is double)
            {
                double xValue = (double)x.Cells[ColumnIndex].Tag;
                double yValue = (double)y.Cells[ColumnIndex].Tag;
                return SortMultiplier * (int)(yValue - xValue);
            }
            if(x.Cells[ColumnIndex].Tag as IComparable != null && (x.Cells[ColumnIndex].Tag.GetType().Equals(y.Cells[ColumnIndex].Tag.GetType())))
            {
                return SortMultiplier * ((IComparable)x.Cells[ColumnIndex].Tag).CompareTo(y.Cells[ColumnIndex].Tag);
            }
            string s1 = x.Cells[ColumnIndex].Value != null ? x.Cells[ColumnIndex].Value.ToString() : "";
            string s2 = y.Cells[ColumnIndex].Value != null ? y.Cells[ColumnIndex].Value.ToString() : "";
            return SortMultiplier * string.Compare(s1, s2);
        }

        #endregion

        #endregion
    }
}
