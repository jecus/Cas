using System.Collections.Generic;
using CAS.UI.Management.Dispatchering.DispatcheredUIControls;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// Сравнялка <see cref="ReferenceAvalonButtonM"/>
    /// </summary>
    internal class ReferenceAvalonButtonMComparer : IComparer<ReferenceAvalonButtonM>
    {

        #region IComparer<ReferenceAvalonButtonM> Members

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
        public int Compare(ReferenceAvalonButtonM x, ReferenceAvalonButtonM y)
        {
            return string.Compare(x.Text, y.Text);
        }

        #endregion
    }
}
