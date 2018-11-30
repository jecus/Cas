using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.FiltersControls;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Фильтр директив по названию
    /// </summary>
    public class DirectiveTitleFilterControl : AbstractDirectiveTextFilterControl
    {

        #region Methods

        #region public override IFilter GetFilter()

        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        public override IFilter GetFilter()
        {
            return new DirectiveTitleFilter(Mask);
        }

        #endregion

        #region public override void SetFilterParameters(IFilter filter)

        /// <summary>
        /// Задаются параметры фильтра
        /// </summary>
        /// <param name="filter">Источник параметров фильтра</param>
        public override void SetFilterParameters(IFilter filter)
        {
            if (filter is DirectiveTitleFilter)
            {
                DirectiveTitleFilter titleFilter = (DirectiveTitleFilter)filter;
                Mask = titleFilter.Mask;
                SerialFilterAppliance = true;
            }

        }

        #endregion

        #endregion


    }
}