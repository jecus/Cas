using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LTR.Core;

namespace LTR.UI.UIControls.Auxiliary
{
    internal class ListViewComparer 
    {
        #region internal class ListViewIntComparer:IComparer

        /// <summary>
        /// Класс отвечающий за сравнение по полю типа Int
        /// </summary>
        internal class ListViewIntComparer:IComparer
        {
            #region IComparer Members

            ///<summary>
            ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            ///</summary>
            ///
            ///<returns>
            ///Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y. 
            ///</returns>
            ///
            ///<param name="y">The second object to compare. </param>
            ///<param name="x">The first object to compare. </param>
            ///<exception cref="T:System.ArgumentException">Neither x nor y implements the <see cref="T:System.IComparable"></see> interface.-or- x and y are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
            public int Compare(object x, object y)
            {
                int tempX = Convert.ToInt32(x);
                int tempY = Convert.ToInt32(y);
                if (tempX > tempY) return 1;
                if (tempX < tempY) return -1;
                return 0;
            }

            #endregion
        }

        #endregion

        #region internal class ListViewStringComparer : IComparer

        /// <summary>
        /// Класс отвечающий за сравнение по полю типа String
        /// </summary>
        internal class ListViewStringComparer : IComparer
        {
            #region IComparer Members

            ///<summary>
            ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            ///</summary>
            ///
            ///<returns>
            ///Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y. 
            ///</returns>
            ///
            ///<param name="y">The second object to compare. </param>
            ///<param name="x">The first object to compare. </param>
            ///<exception cref="T:System.ArgumentException">Neither x nor y implements the <see cref="T:System.IComparable"></see> interface.-or- x and y are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
            public int Compare(object x, object y)
            {
                string tempX = Convert.ToString(x);
                string tempY = Convert.ToString(y);
                return String.Compare(tempX, tempY);
            }

            #endregion

        }

        #endregion

        #region internal class ListViewDateTimeComparer : IComparer

        /// <summary>
        /// Класс отвечающий за сравнение по полю типа DateTime
        /// </summary>
        internal class ListViewDateTimeComparer : IComparer
        {
            #region IComparer Members

            ///<summary>
            ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
            ///</summary>
            ///
            ///<returns>
            ///Value Condition Less than zero x is less than y. Zero x equals y. Greater than zero x is greater than y. 
            ///</returns>
            ///
            ///<param name="y">The second object to compare. </param>
            ///<param name="x">The first object to compare. </param>
            ///<exception cref="T:System.ArgumentException">Neither x nor y implements the <see cref="T:System.IComparable"></see> interface.-or- x and y are of different types and neither one can handle comparisons with the other. </exception><filterpriority>2</filterpriority>
            public int Compare(object x, object y)
            {
                DateTime tempX = Convert.ToDateTime(x);
                DateTime tempY = Convert.ToDateTime(y);
                return DateTime.Compare(tempX, tempY);
            }

            #endregion
        }

        #endregion

    }
}
