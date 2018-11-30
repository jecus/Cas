using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Directives;
using LTR.Core.Types.ReportFilters;
using LTRReports.Datasets;

namespace LTRReports
{
    /// <summary>
    /// Построение отчета SB status
    /// </summary>
    public class SBReportBuilder:DirectiveListReportBuilder
    {
        SBStatusFilter defaultFilter = new SBStatusFilter();
        #region Constructors

        #region public SBReportBuilder()

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public SBReportBuilder()
        {
        }

        #endregion

        #region public SBReportBuilder(BaseDetailDirective[] directives) : base(directives)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных директив
        /// </summary>
        /// <param name="directives">Элементы для которых создается отчет</param>
        public SBReportBuilder(BaseDetailDirective[] directives) : base(directives)
        {
        }

        #endregion

        #region public SBReportBuilder(Operator reportedOperator) : base(reportedOperator)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного Оператора, его ВС и базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedOperator">Элемент для которого создается отчет</param>
        public SBReportBuilder(Operator reportedOperator) : base(reportedOperator)
        {
        }

        #endregion

        #region public SBReportBuilder(Operator[] reportedOperators) : base(reportedOperators)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных операторов, их ВС для базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedOperators">Элементы для которых создается отчет</param>
        public SBReportBuilder(Operator[] reportedOperators) : base(reportedOperators)
        {
        }

        #endregion

        #region public SBReportBuilder(Aircraft[] reportedAircrafts) : base(reportedAircrafts)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных самолетов, их базовых агрегатов и директив, содержащихся в них
        /// </summary>
        /// <param name="reportedAircrafts">Элементы для которых создается отчет</param>
        public SBReportBuilder(Aircraft[] reportedAircrafts) : base(reportedAircrafts)
        {
        }

        #endregion

        #region public SBReportBuilder(Aircraft reportedAircraft) : base(reportedAircraft)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного ВС, его базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedAircraft">Элемент для которого создается отчет</param>
        public SBReportBuilder(Aircraft reportedAircraft) : base(reportedAircraft)
        {
        }

        #endregion

        #region public SBReportBuilder(BaseDetail[] reportedBaseDetails) : base(reportedBaseDetails)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedBaseDetails">Элементы для которых создается отчет</param>
        public SBReportBuilder(BaseDetail[] reportedBaseDetails) : base(reportedBaseDetails)
        {
        }

        #endregion

        #region public SBReportBuilder(BaseDetail reportedBaseDetail) : base(reportedBaseDetail)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного базового агрегата и всех его директив
        /// </summary>
        /// <param name="reportedBaseDetail">Элемент для которого создается отчет</param>
        public SBReportBuilder(BaseDetail reportedBaseDetail) : base(reportedBaseDetail)
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
                return "SB Status Compliance List";
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
