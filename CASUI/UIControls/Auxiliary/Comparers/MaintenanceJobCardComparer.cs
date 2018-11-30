using System.Collections.Generic;
using CAS.Core.Types.Directives;

namespace CAS.UI.UIControls.Auxiliary.Comparers
{
    /// <summary>
    /// Сравнивалка <see cref="JobCard"/>
    /// </summary>
    public class MaintenanceJobCardsComparer : IComparer<JobCard>
    {

        #region Fields

        private readonly int columnSortMultiplier;

        #endregion
        
        #region Constructor

        public MaintenanceJobCardsComparer(int columnSortMultiplier)
        {
            this.columnSortMultiplier = columnSortMultiplier;
        }

        #endregion
        
        #region IComparer<MaintenanceJobCard> Members

        public int Compare(JobCard x, JobCard y)
        {
            return columnSortMultiplier*string.Compare(x.AirlineCardNumber, y.AirlineCardNumber);
        }

        #endregion
    }

}