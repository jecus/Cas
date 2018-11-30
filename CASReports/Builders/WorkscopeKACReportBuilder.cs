using System.Collections.Generic;
using CASReports.ReportTemplates;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    public class WorkscopeReportBuilderKAC : WorkscopeReportBuilder
    {

        #region Fields

        private string _reportTitle = "WORK SCOPE";
        private string _filterSelection;
        private byte[] _operatorLogotype;
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private WorkPackage _workPackage;
        private List<BaseEntityObject> _reportedDirectives = new List<BaseEntityObject>();

        private Forecast _forecast;
        private string _dateAsOf = "";

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            WorkscopeReportKAC report = new WorkscopeReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #endregion

    }
}