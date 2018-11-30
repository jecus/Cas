using CASReports.ReportTemplates;

namespace CASReports.Builders
{
    public class MaintenanceDirectivesReportBuilder : MaintenanceDirectivesFullReportBuilder
    {

        public MaintenanceDirectivesReportBuilder()
        {
            ReportTitle = "MAINTENANCE PROGRAM";
        }

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MaintenanceDirectiveReport report = new MaintenanceDirectiveReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #endregion

    }
}