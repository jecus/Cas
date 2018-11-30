using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    internal class DirectiveComplianceListViewComparer : IComparer<ListViewItem>
    {

        #region Fields

        private readonly int columnIndex = 0;
        private readonly int sortMultiplier;

        #endregion

        #region Constructors

        #region public DirectiveComplianceListViewComparer(int columnIndex)

        /// <summary>
        /// Создает компаратор для DirectiveListView
        /// </summary>
        /// <param name="columnIndex"></param>
        public DirectiveComplianceListViewComparer(int columnIndex)
        {
            this.columnIndex = columnIndex;
        }

        #endregion

        #region public DirectiveComplianceListViewComparer(int index, int sortMultiplier) : this(index)

        public DirectiveComplianceListViewComparer(int index, int sortMultiplier)
            : this(index)
        {
            this.sortMultiplier = sortMultiplier;
        }

        #endregion

        #endregion

        #region Methods

        #region public int Compare(object x, object y)

        public int Compare(ListViewItem x, ListViewItem y)
        {
            if (columnIndex == 0)
            {
                return
                    sortMultiplier *
                    DateTime.Compare(Convert.ToDateTime(x.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)),
                                     Convert.ToDateTime(y.SubItems[columnIndex].Text, new CultureInfo("ru-Ru", true)));
            }
            return sortMultiplier * string.Compare(x.SubItems[columnIndex].Text, y.SubItems[columnIndex].Text);
        }
        #endregion

        #endregion


    }
}