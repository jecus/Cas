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

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение CPCP директив для базового агрегата
    /// </summary>
    public class DispatcheredCPCPDirectiveListScreen : DispatcheredDirectivesView
    {
        /// <summary>
        /// Создается элемент - отображение CPCPStatus директив для базового агрегата
        /// </summary>
        /// <param name="currentItem">Отображаемый объект</param>
        public DispatcheredCPCPDirectiveListScreen(BaseDetail currentItem)
            : base(currentItem)
        {
        }

        /// <summary>
        /// Отображение директив для всего ВС
        /// </summary>
        /// <param name="currentItem">ВС, для которого отображаются директивы</param>
        public DispatcheredCPCPDirectiveListScreen(Aircraft currentItem) : base(currentItem, null)
        {
        }

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return DirectiveTypeCollection.Instance.CPCPDirectiveType.CommonName; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DirectiveListReportBuilder CreateReportBuilder()
        {
            return new CPCPReportBuilder();
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return DirectiveTypeCollection.Instance.CPCPDirectiveType; }
        }

        /// <summary>
        /// SDList для директив
        /// </summary>
        public override SDList<BaseDetailDirective> DirectiveListView
        {
            get { return new CPCPDirectiveListView(); }
        }

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected override DirectiveFilter[] GetCollectionFilters()
        {
            return new DirectiveFilter[1] { new CPCPFilter() };
        }

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredCPCPDirectiveListScreen);
        }
    }
}