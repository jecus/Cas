using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    internal class CertainGroupsOrderListViewComparer : IComparer<ListViewItem>
    {
        #region Fields
        
        private readonly int columnIndex;
        private readonly int sortMultiplier = 1;
        private readonly List<string> groups;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает компаратор для ListViewItem
        /// </summary>
        /// <param name="columnIndex">Индекс столбца, по которому идет сортировка</param>
        /// <param name="sortMultiplier">Направление сортировки</param>
        /// <param name="groups">Порядок групп</param>
        public CertainGroupsOrderListViewComparer(int columnIndex, int sortMultiplier, List<string> groups)
        {
            this.columnIndex = columnIndex;
            this.sortMultiplier = sortMultiplier;
            this.groups = groups;
        }

        #endregion

        #region Methods

        #region public int Compare(ListViewItem x, ListViewItem y)

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
            {
                if (groups.IndexOf(x.Group.Name) > groups.IndexOf(y.Group.Name))
                    return 1;
                else if (groups.IndexOf(x.Group.Name) < groups.IndexOf(y.Group.Name))
                    return -1;
                else
                    return 0;
            }
            return sortMultiplier * String.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }

        #endregion

        #endregion
    }
}
