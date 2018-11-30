using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.ReportFilters;
using LTR.UI.Interfaces;
using LTRReports;
using LTRReports.Builders;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Класс, описывающий отображение AgingProgram директив для базового агрегата
    /// </summary>
    public class DispatcheredAgingProgramView : DispatcheredDirectivesView
    {
        /// <summary>
        /// Создается элемент - отображение AgingProgram директив для базового агрегата
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public DispatcheredAgingProgramView(BaseDetail currentItem)
            : base(currentItem)
        {
        }

        /// <summary>
        /// Отображение директив для всего ВС
        /// </summary>
        /// <param name="currentItem">ВС, для которого отображаются директивы</param>
        public DispatcheredAgingProgramView(Aircraft currentItem)
            : base(currentItem)
        {
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return "Aging program"; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DirectiveListReportBuilder CreateReportBuilder()
        {
            return new AgingProgramReportBuilder();
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return DirectiveTypeCollection.Instance.GetByID((int)DirectiveTypeID.AgingProgramDirectiveTypeID); }
        }

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected override DirectiveFilter[] GetCollectionFilters()
        {
            return new DirectiveFilter[1] { new AgingProgramFilter() };
        }

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredAgingProgramView);
        }
    }
}
