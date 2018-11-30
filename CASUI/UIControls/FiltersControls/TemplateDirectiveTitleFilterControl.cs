using CAS.Core.Types.ReportFilters;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    public class TemplateDirectiveTitleFilterControl : AbstractDirectiveTextFilterControl
    {

        #region Methods

        #region public override IFilter GetFilter()

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public override IFilter GetFilter()
        {
            return new TemplateDirectiveTitleFilter(Mask);
        }

        #endregion

        #region public override void SetFilterParameters(IFilter filter)

        /// <summary>
        /// Задаются параметры фильтра
        /// </summary>
        /// <param name="filter">Источник параметров фильтра</param>
        public override void SetFilterParameters(IFilter filter)
        {
            if (filter is TemplateDirectiveTitleFilter)
            {
                TemplateDirectiveTitleFilter titleFilter = (TemplateDirectiveTitleFilter)filter;
                Mask = titleFilter.Mask;
                SerialFilterAppliance = true;
            }

        }

        #endregion

        #endregion

    }
}