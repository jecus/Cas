using System.Collections.Generic;
using CAS.UI.UIControls.AircraftsControls;
using CAS.UI.UIControls.StoresControls;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{

    #region public class AircraftReferenceStatusImageLinkLabelComparer : IComparer<AircraftReferenceStatusImageLinkLabel>

    /// <summary>
    /// Сравнивалка <see cref="AircraftReferenceStatusImageLinkLabel"/>
    /// </summary>
    public class AircraftReferenceStatusImageLinkLabelComparer : IComparer<AircraftReferenceStatusImageLinkLabel>
    {
        #region IComparer<AircraftReferenceStatusImageLinkLabel> Members
        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(AircraftReferenceStatusImageLinkLabel x, AircraftReferenceStatusImageLinkLabel y)
        {
            return string.Compare(x.Text, y.Text);
        }
        #endregion
    }

    #endregion
/*    
    #region public class StoreListItemComparer : IComparer<StoreListItem>

    /// <summary>
    /// Сравнивалка <see cref="StoreListItem"/>
    /// </summary>
    public class StoreListItemComparer : IComparer<StoreListItem>
    {
        #region IComparer<OperatorListItem> Members
        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(StoreListItem x, StoreListItem y)
        {
            return string.Compare(x.Text, y.Text);
        }
        #endregion
    }

    #endregion*/
    
}