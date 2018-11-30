using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий элемент отображения фильтра состояния
    ///</summary>
    public class DirectiveConditionFilterControl:ConditionStatusControl
    {
        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public override IFilter GetFilter()
        {
            return CreateDirectiveFilter();
        }

        ///<summary>
        ///
        /// Задаются параметры фильтра
        /// 
        ///</summary>
        ///
        ///<param name="filter">Источник параметров фильтра</param>
        public override void SetFilterParameters(IFilter filter)
        {
            if (filter is DirectiveConditionFilter)
            {
                DirectiveConditionFilter directiveConditionFilter = (DirectiveConditionFilter) filter;
                SatisfactoryAppliance = directiveConditionFilter.SatisfactoryAcceptance;
                NotificationAppliance = directiveConditionFilter.NotificationAcceptance;
                UnsatisfactoryAppliance = directiveConditionFilter.NotSatisfactoryAcceptance;
            }
        }

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public DirectiveConditionFilter CreateDirectiveFilter()
        {
            DirectiveConditionFilter filter = new DirectiveConditionFilter(SatisfactoryAppliance, UnsatisfactoryAppliance, NotificationAppliance);
            return filter;
        }

        
    }
}