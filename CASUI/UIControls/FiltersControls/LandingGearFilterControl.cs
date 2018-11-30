using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LandingGearFilterControl : UserControl, IFilterControl
    {
        /// <summary>
        /// 
        /// </summary>
        public LandingGearFilterControl()
        {
            InitializeComponent();
        }

        #region IFilterControl Members

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public IFilter GetFilter()
        {
            return new LandingGearsFilter(checkBoxGeneral.Checked, checkBoxLeft.Checked, checkBoxRigth.Checked, true);
        }

        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get
            {
                return true;
            }
            set { }
        }

        #endregion
    }
}