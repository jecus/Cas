using System.Collections.Generic;
using CAS.Core.Types.WorkPackages;

namespace CAS.UI.UIControls.WorkPackages
{
    internal class WorkPackageComparer : IComparer<WorkPackage>
    {
        #region IComparer<WorkPackage> Members

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
        public int Compare(WorkPackage x, WorkPackage y)
        {
            return string.Compare(x.Title, y.Title);
        }

        #endregion
    }
}
