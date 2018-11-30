using System.Collections.Generic;
using CAS.Core.Types.Aircrafts;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// Сравнивалка <see cref="TemplateAircraft"/> по модели
    /// </summary>
    public class TemplateAircraftModelComparer: IComparer<TemplateAircraft>
    {
        #region IComparer<TemplateAircraft> Members

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
        public int Compare(TemplateAircraft x, TemplateAircraft y)
        {
            return string.Compare(x.Model, y.Model);
        }

        #endregion
    }
}
