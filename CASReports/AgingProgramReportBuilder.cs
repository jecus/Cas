using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Directives;
using LTR.Core.Types.ReportFilters;

namespace LTRReports
{
    /// <summary>
    /// Построение отчета AD Status
    /// </summary>
    public class AgingProgramReportBuilder : DirectiveListReportBuilder
    {
        private AgingProgramFilter defaultFilter = new AgingProgramFilter();

        #region Constructors

        #region public AgingProgramReportBuilder()

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public AgingProgramReportBuilder()
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(BaseDetailDirective[] directives) : base(directives)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных директив
        /// </summary>
        /// <param name="directives">Элементы для которых создается отчет</param>
        public AgingProgramReportBuilder(BaseDetailDirective[] directives)
            : base(directives)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(Operator reportedOperator) : base(reportedOperator)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного Оператора, его ВС и базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedOperator">Элемент для которого создается отчет</param>
        public AgingProgramReportBuilder(Operator reportedOperator)
            : base(reportedOperator)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(Operator[] reportedOperators) : base(reportedOperators)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных операторов, их ВС для базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedOperators">Элементы для которых создается отчет</param>
        public AgingProgramReportBuilder(Operator[] reportedOperators)
            : base(reportedOperators)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(Aircraft[] reportedAircrafts) : base(reportedAircrafts)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных самолетов, их базовых агрегатов и директив, содержащихся в них
        /// </summary>
        /// <param name="reportedAircrafts">Элементы для которых создается отчет</param>
        public AgingProgramReportBuilder(Aircraft[] reportedAircrafts)
            : base(reportedAircrafts)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(Aircraft reportedAircraft) : base(reportedAircraft)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного ВС, его базовых агрегатов и всех его директив
        /// </summary>
        /// <param name="reportedAircraft">Элемент для которого создается отчет</param>
        public AgingProgramReportBuilder(Aircraft reportedAircraft)
            : base(reportedAircraft)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(BaseDetail[] reportedBaseDetails) : base(reportedBaseDetails)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданных базовых агрегатов и всех директив
        /// </summary>
        /// <param name="reportedBaseDetails">Элементы для которых создается отчет</param>
        public AgingProgramReportBuilder(BaseDetail[] reportedBaseDetails)
            : base(reportedBaseDetails)
        {
        }

        #endregion

        #region public AgingProgramReportBuilder(BaseDetail reportedBaseDetail) : base(reportedBaseDetail)

        /// <summary>
        /// Создается объект для создания отчетов директив для заданного базового агрегата и всех его директив
        /// </summary>
        /// <param name="reportedBaseDetail">Элемент для которого создается отчет</param>
        public AgingProgramReportBuilder(BaseDetail reportedBaseDetail)
            : base(reportedBaseDetail)
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
                return "Aging program directives List";
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
