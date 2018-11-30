/*using CASReports.Builders;
using CASReports.ReportTemplates;
using CAS.Core.Types.ReportFilters;

namespace CASReports.Builders
{
    /// <summary>
    /// Построение отчета AD Status
    /// </summary>
    public class SSIDReportBuilder : DirectiveListReportBuilder
    {

        #region Fields

        private readonly SSIDStatusFilter defaultFilter = new SSIDStatusFilter();

        #endregion

        #region Constructor

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public SSIDReportBuilder()
        {
            ReportTitle = "SSID status";
        }

        #endregion
        
        #region Properties

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

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ADReport report = new ADReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #endregion
    }
}*/