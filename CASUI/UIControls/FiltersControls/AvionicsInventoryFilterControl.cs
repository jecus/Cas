using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AvionicsInventoryFilterControl : UserControl, IFilterControl
    {
        /// <summary>
        /// 
        /// </summary>
        public AvionicsInventoryFilterControl()
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
            return new AvionicsInventoryFilter(checkBoxOptional.Checked, checkBoxRequired.Checked, true);//todo
        }

        public void SetFilterParameters(IFilter filter)
        {
            
        }

        ///<summary>
        /// Применимость фильтра
        ///</summary>
        public bool FilterAppliance
        {
            get { return checkBoxRequired.Checked != checkBoxOptional.Checked; }
            set { }
        }

        #endregion
    }
}