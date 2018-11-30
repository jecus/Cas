using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий элемент отображения фильтра состояния
    ///</summary>
    public class DetailConditionFilterControl:ConditionStatusControl
    {
        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public override IFilter GetFilter()
        {
            return CreateDetailFilter();
        }

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public DetailConditionFilter CreateDetailFilter()
        {
            DetailConditionFilter filter = new DetailConditionFilter(SatisfactoryAppliance, UnsatisfactoryAppliance, NotificationAppliance);
            return filter;
        }

        public override void SetFilterParameters(IFilter filter)
        {
        }
    }
}