using CASReports.ReportTemplates;

namespace CASReports.Builders
{
    public class ComponentLLPReportBuilderKAC : ComponentLLPReportBuilder
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region public ComponentLLPReportBuilderKAC()

        public ComponentLLPReportBuilderKAC()
        {
            ReportTitle = "Engine Life Limited Parts Status";
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
            ComponentListLLPReportKAC report = new ComponentListLLPReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #endregion

    }
}
