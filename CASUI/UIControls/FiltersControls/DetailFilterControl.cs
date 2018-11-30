using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий отображение фильтра коллекции агрегатов
    ///</summary>
    public partial class DetailFilterControl : UserControl
    {
        private MaintenanceFilterControl maintenanceFilterControl;
        private ATAChapterFilterControl ataChapterFilterControl;

        ///<summary>
        /// Создается элемент отображения фильтра коллекции агрегатов
        ///</summary>
        public DetailFilterControl()
        {
            InitializeComponent();
            maintenanceFilterControl = new MaintenanceFilterControl(MaintenanceTypeCollection.Instance);
            ataChapterFilterControl = new ATAChapterFilterControl(ATAChapterCollection.Instance);
            tableLayoutPanel1.Controls.Add(maintenanceFilterControl, 2, 0);
            tableLayoutPanel1.Controls.Add(ataChapterFilterControl, 3, 0);
        }

        ///<summary>
        /// Создается фильтр коллекции агрегатов
        ///</summary>
        ///<returns></returns>
        public DetailCollectionFilter GetDetailCollectionFilter()
        {
            List<DetailFilter> filters = new List<DetailFilter>(); 
            if (maintenanceFilterControl.FilterAppliance) filters.Add(maintenanceFilterControl.GetFilter() as DetailFilter);
            if (ataChapterFilterControl.FilterAppliance) filters.Add(ataChapterFilterControl.GetFilter() as DetailFilter);
            if (detailConditionFilterControl1.FilterAppliance) filters.Add(detailConditionFilterControl1.GetFilter() as DetailFilter);
            if (serialNoFilterControl1.FilterAppliance) filters.Add(serialNoFilterControl1.GetFilter() as DetailFilter);
            if (partNoFilterControl1.FilterAppliance) filters.Add(partNoFilterControl1.GetFilter() as DetailFilter);
            return new DetailCollectionFilter(filters.ToArray());
        }
    }
}