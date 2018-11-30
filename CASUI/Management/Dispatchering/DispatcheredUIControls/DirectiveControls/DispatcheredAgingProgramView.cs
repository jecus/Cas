using System;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DirectivesControls;
using CASReports.Builders;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CASReports;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
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
        public DispatcheredAgingProgramView(Aircraft currentItem) : base(currentItem, null)
        {
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return DirectiveTypeCollection.Instance.AgineProgramDirectiveType.CommonName; }
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
            get { return DirectiveTypeCollection.Instance.AgineProgramDirectiveType; }
        }

        /// <summary>
        /// SDList для директив
        /// </summary>
        public override SDList<BaseDetailDirective> DirectiveListView
        {
            get { return new DirectiveListView(); }
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