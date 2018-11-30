using System.Collections.Generic;
using CAS.Core.Types.Aircrafts.Parts;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{

    /// <summary>
    /// Сравнялка <see cref="Engine"/>
    /// </summary>
    public class EnginePositionSerialNumberComparer : IComparer<Engine>
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
            return string.Compare(x.PositionNumber, y.PositionNumber) == 0 ? string.Compare(x.SerialNumber, y.SerialNumber) : string.Compare(x.PositionNumber, y.PositionNumber);
        }

        #endregion
    }
     

    

}
