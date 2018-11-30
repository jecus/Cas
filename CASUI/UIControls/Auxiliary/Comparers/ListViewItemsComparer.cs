using System.Collections.Generic;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// Сравнивалка <see cref="ListViewItem"/>-ов
    /// </summary>
    public class ListViewItemsComparer : IComparer<ListViewItem>
    {
        #region Fields

        private readonly int columnIndex;
        private readonly int sortMultiplier;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает сравнивалку <see cref="ListViewItem"/>
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="sortMultiplier"></param>
        public ListViewItemsComparer(int columnIndex, int sortMultiplier)
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
            if (x.Group != y.Group)
                return 0;
            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }

        #endregion

        #endregion
    }
}
