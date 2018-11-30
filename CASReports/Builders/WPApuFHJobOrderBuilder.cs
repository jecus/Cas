using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета WPApuFHJobOrderBuilder
    /// </summary>
    public class WPApuFHJobOrderBuilder
    {
        #region Fields

        private WorkPackage _currentWorkPackage;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создается построитель отчета WPApuFHJobOrderReport 
        /// </summary>
        /// <param name="currentWorkPackage">Рабочий пакет</param>
        public WPApuFHJobOrderBuilder(WorkPackage currentWorkPackage)
        {
            _currentWorkPackage = currentWorkPackage;
        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region public object GenerateReport()
        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public object GenerateReport()
        {
            WPApuFHJobOrderReport report = new WPApuFHJobOrderReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private WPApuFHJobOrderDataSet GenerateDataSet()

        private WPApuFHJobOrderDataSet GenerateDataSet()
        {
            WPApuFHJobOrderDataSet dataSet = new WPApuFHJobOrderDataSet();
            AddAdditionalDataToDataSet(dataSet);
            AddMainInformationToDataSet(dataSet);
            AddAircraftToDataset(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddMainInformationToDataSet(WPApuFHJobOrderDataSet destinationDataSet)

        private void AddMainInformationToDataSet(WPApuFHJobOrderDataSet destinationDataSet)
        {
            destinationDataSet.MainTable.AddMainTableRow("",
                                                         _currentWorkPackage.Title,
                                                         _currentWorkPackage.Station);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(WPApuFHJobOrderDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(WPApuFHJobOrderDataSet destinationDateSet)
        {
            var reportHeader = "Component Change Order";
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _currentWorkPackage.Aircraft.OperatorId).LogotypeReportLarge, reportHeader, "", "", "", reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region private void AddAircraftToDataset(WPApuFHJobOrderDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(WPApuFHJobOrderDataSet destinationDataSet)
        {
            if (_currentWorkPackage.Aircraft == null)
                return;
	        var aircraftLifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentWorkPackage.Aircraft);
			string serialNumber = _currentWorkPackage.Aircraft.SerialNumber;
            string manufactureDate = _currentWorkPackage.Aircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string sinceNewHours = aircraftLifelength.Hours.ToString();
            string sinceNewCycles = aircraftLifelength.Cycles.ToString().Trim();
            string lineNumberCaption = "";
            string variableNumberCaption = "";
            string lineNumber = _currentWorkPackage.Aircraft.LineNumber;
            string variableNumber = _currentWorkPackage.Aircraft.VariableNumber;
            if (lineNumber != "")
                lineNumberCaption = "L/N:";
            if (variableNumber != "")
                variableNumberCaption = "V/N:";
            destinationDataSet.AircraftInformationTable.AddAircraftInformationTableRow(_currentWorkPackage.Aircraft.RegistrationNumber, serialNumber,
                                                                     manufactureDate, _currentWorkPackage.Aircraft.Model.ToString(),lineNumberCaption, variableNumberCaption, lineNumber,
                                                                     variableNumber, sinceNewHours, sinceNewCycles);
        }

        #endregion
       
        #endregion
    }
}
