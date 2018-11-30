using System;
using System.Collections.Generic;
using System.Text;
using CAS.Core.Types.Directives;
using CAS.UI.UIControls.DirectivesControls;
using CASReports;
using CASReports.Builders;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение директив для заданого типа директив
    /// </summary>
    public class DispatcheredСertainDirectivesView:DispatcheredDirectivesView
    {
        private string reportTitileText;
        private DirectiveType directiveDefaultType;
        private DirectiveFilter[] directiveFilters;
        private SortedList<string, IFilter> dictionaryDirectiveFilters;
        private BaseDetailDirective currentDirective;

        #region public DispatcheredСertainDirectivesView(Directive directive): base(directive.Parent as IDirectiveContainer)

        /// <summary>
        /// Создается элемент - отображение директив для заданого типа директив
        /// </summary>
        /// <param name="directive">Директива для которой требуется создать элемент - отображения</param>
        public DispatcheredСertainDirectivesView(BaseDetailDirective directive)
        {
            currentDirective = directive;
            dictionaryDirectiveFilters = (SortedList<string, IFilter>)(new TermsProvider()[("DirectiveFilterTypes")]);
            reportTitileText = directive.DirectiveType.CommonName;
            directiveFilters = new DirectiveFilter[]{dictionaryDirectiveFilters[directive.DirectiveType.CommonName] as DirectiveFilter};
            directiveDefaultType = directive.DirectiveType;
            Initialize((directive.Parent is AircraftFrame ? directive.Parent.Parent:directive.Parent)  as IDirectiveContainer);
        }

        #endregion


        
        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitileText
        {
            get { return reportTitileText; }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override DirectiveListReportBuilder CreateReportBuilder()
        {
            //ReportTypesProvider r = new ReportTypesProvider();
            return (DirectiveListReportBuilder)InstanceProvider.CreateInstance(new ReportTypesProvider().ReportTypes[currentDirective.DirectiveType]);
            //return new DirectiveListReportBuilder();
        }

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public override DirectiveType DirectiveDefaultType
        {
            get { return directiveDefaultType; }
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
            return directiveFilters;
        }

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected override bool IsSameType(IDisplayingEntity obj)
        {
            return (obj is DispatcheredDirectivesView);
        }
    }
}
