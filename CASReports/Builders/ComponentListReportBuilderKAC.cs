using CASReports.ReportTemplates;

namespace CASReports.Builders
{
    public class ComponentListReportBuilderKAC : ComponentListReportBuilder
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public ComponentListReportBuilderKAC()

        public ComponentListReportBuilderKAC()
        {
            ReportTitle = "HARD TIME COMPONENTS STATUS";
        }
        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ComponentListReportKAC report = new ComponentListReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #endregion

    }
}
