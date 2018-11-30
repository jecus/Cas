using System.Collections.Generic;
using LTR.Core.Types.Aircrafts.Parts;

namespace LTR.UI.UIControls.Auxiliary.Comparers
{
    class EnginePartNumberComparer : IComparer<Engine>
    {
        #region IComparer<Engine> Members

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
        public int Compare(Engine x, Engine y)
        {
            return string.Compare(y.PartNumber, x.PartNumber);
        }

        #endregion
    }
}
