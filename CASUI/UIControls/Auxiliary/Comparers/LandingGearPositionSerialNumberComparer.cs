using System.Collections.Generic;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Aircrafts.Parts.Templates;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{

    #region public class LandingGearPositionSerialNumberComparer : IComparer<GearAssembly>

    /// <summary>
    /// Сравнивалка <see cref="Detail"/>
    /// </summary>
    public class LandingGearPositionSerialNumberComparer : IComparer<GearAssembly>
    {
        #region IComparer<Detail> Members

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
        public int Compare(GearAssembly x, GearAssembly y)
        {
            return string.Compare(x.PositionNumber, y.PositionNumber) == 0 ? string.Compare(x.SerialNumber, y.SerialNumber) : string.Compare(x.PositionNumber, y.PositionNumber);
        }

        #endregion
    }

    #endregion

    #region public class TemplateGearAssemblyPartNumberComparer : IComparer<TemplateGearAssembly>

    /// <summary>
    /// Сравнивалка <see cref="TemplateDetail"/>
    /// </summary>
    public class TemplateGearAssemblyPartNumberComparer : IComparer<TemplateGearAssembly>
    {
        #region IComparer<Detail> Members

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
        public int Compare(TemplateGearAssembly x, TemplateGearAssembly y)
        {
            return string.Compare(x.PartNumber, y.PartNumber);
        }

        #endregion
    }

    #endregion
}
