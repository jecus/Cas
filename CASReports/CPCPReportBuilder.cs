using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Directives;
using LTR.Core.Types.ReportFilters;

namespace LTRReports
{
    /// <summary>
    /// Класс для построения отчетов CPCP Status
    /// </summary>
    public class CPCPReportBuilder:DirectiveListReportBuilder
    {
        private readonly CPCPFilter defaultFilter = new CPCPFilter();

        #region Constructors

        #region public CPCPReportBuilder()

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public CPCPReportBuilder()
        {
        }

        #endregion

        #region public CPCPReportBuilder(BaseDetailDirective[] directives) : base(directives)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных директив
        /// </summary>
        /// <param name="directives">Элементы для которых создается отчет</param>
        public CPCPReportBuilder(BaseDetailDirective[] directives) : base(directives)
        {
        }

        #endregion

        #region public CPCPReportBuilder(Operator reportedOperator) : base(reportedOperator)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного Оператора, его ВС и базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedOperator">Элемент для которого создается отчет</param>
        public CPCPReportBuilder(Operator reportedOperator) : base(reportedOperator)
        {
        }

        #endregion

        #region public CPCPReportBuilder(Operator[] reportedOperators) : base(reportedOperators)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных операторов, их ВС для базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedOperators">Элементы для которых создается отчет</param>
        public CPCPReportBuilder(Operator[] reportedOperators) : base(reportedOperators)
        {
        }

        #endregion

        #region public CPCPReportBuilder(Aircraft[] reportedAircrafts) : base(reportedAircrafts)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных самолетов, их базовых агрегатов и директив, содержащихся в них
        /// </summary>
        /// <param name="reportedAircrafts">Элементы для которых создается отчет</param>
        public CPCPReportBuilder(Aircraft[] reportedAircrafts) : base(reportedAircrafts)
        {
        }

        #endregion

        #region public CPCPReportBuilder(Aircraft reportedAircraft) : base(reportedAircraft)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного ВС, его базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedAircraft">Элемент для которого создается отчет</param>
        public CPCPReportBuilder(Aircraft reportedAircraft) : base(reportedAircraft)
        {
        }

        #endregion

        #region public CPCPReportBuilder(BaseDetail[] reportedBaseDetails) : base(reportedBaseDetails)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedBaseDetails">Элементы для которых создается отчет</param>
        public CPCPReportBuilder(BaseDetail[] reportedBaseDetails) : base(reportedBaseDetails)
        {
        }

        #endregion

        #region public CPCPReportBuilder(BaseDetail reportedBaseDetail) : base(reportedBaseDetail)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного базового агрегата и всех его директив
        /// </summary>
        /// <param name="reportedBaseDetail">Элемент для которого создается отчет</param>
        public CPCPReportBuilder(BaseDetail reportedBaseDetail) : base(reportedBaseDetail)
        {
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public override string ReportTitle
        {
            get
            {
                return "Corrosion Prevention and Control Program";
            }
            set
            {
            }
        }

        /// <summary>
        /// Фильтр по умолчанию
        /// </summary>
        public override DirectiveFilter DefaultFilter
        {
            get
            {
                return defaultFilter;
            }
        }
        #endregion
    }
}

