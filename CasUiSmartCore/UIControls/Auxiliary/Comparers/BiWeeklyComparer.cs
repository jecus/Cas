using System;
using System.Collections.Generic;
using CAS.Core.Types.Dictionaries;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    public class BiWeeklyComparer : IComparer<BiWeekly>
    {
        #region IComparer<BiWeekly> Members

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
        public int Compare(BiWeekly x, BiWeekly y)
        {
            return string.Compare(y.RealName, x.RealName);
        }

        #endregion
    }
}
