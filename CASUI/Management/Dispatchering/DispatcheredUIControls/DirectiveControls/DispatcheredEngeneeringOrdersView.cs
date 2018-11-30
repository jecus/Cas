using CAS.Core.Types.Aircrafts;
using CASReports.Builders;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение EngeneeringOrders директив для базового агрегата
    /// </summary>
    public class DispatcheredEngeneeringOrdersView : DispatcheredDirectivesView
    {
        /// <summary>
        /// Создается элемент - отображение EngeneeringOrders директив для базового агрегата
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public DispatcheredEngeneeringOrdersView(BaseDetail currentItem)
            : base(currentItem)
        {
        }

        /// <summary>
        /// Отображение директив для всего ВС
        /// </summary>
        /// <param name="currentItem">ВС, для которого отображаются директивы</param>
        public DispatcheredEngeneeringOrdersView(Aircraft currentItem)
            : base(currentItem)
        {
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType.CommonName; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DirectiveListReportBuilder CreateReportBuilder()
        {
            return new EngineeringOrdersReportBuilder();
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return DirectiveTypeCollection.Instance.EngineeringOrdersDirectiveType; }
        }

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected override DirectiveFilter[] GetCollectionFilters()
        {
            return new DirectiveFilter[1] { new EngeneeringOrderFilter() };
        }

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredEngeneeringOrdersView);
        }
    }
}