using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Интерфейс описывающий элемент отображения фильтра
    ///</summary>
    public interface IFilterControl
    {
        ///<summary>
        /// Создание фильтра по заданному состоянию
        ///</summary>
        ///<returns>Созданный фильтр</returns>
        IFilter GetFilter();

        /// <summary>
        /// Задаются параметры фильтра
        /// </summary>
        /// <param name="filter">Источник параметров фильтра</param>
        void SetFilterParameters(IFilter filter);

        #region public bool FilterAppliance
        ///<summary>
        /// Применимость фильтра
        ///</summary>
        bool FilterAppliance
        {
            get;
            set;
        }
        #endregion
    }
}