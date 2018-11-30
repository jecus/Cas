using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Component Change Order по шаблону Авиакомпании Кыргызстан
    /// </summary>
    public class ComponentChangeOrderBuilderKAC
    {
        #region Fields

        private WorkPackage _currentWorkPackage;
        private IEnumerable<Component> _currentDetails;
        private string _workType;
        private int _orderNum;
        
        #endregion

        #region Constructor

        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="currentWorkPackage">Рабочий пакет</param>
        /// <param name="details"></param>
        /// <param name="workType"></param>
        /// <param name="orderNum"></param>
        public ComponentChangeOrderBuilderKAC(WorkPackage currentWorkPackage, IEnumerable<Component> details, string workType, int orderNum)
        {
            if(details == null) return;
            _currentDetails = details;
            _currentWorkPackage = currentWorkPackage;
            _workType = workType;
            _orderNum = orderNum;
        }

        #endregion

        #region Properties
        
        #endregion

        #region Methods

        #region public object GenerateReport()
        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public object GenerateReport()
        {
            ComponentChangeOrderReportKAC report = new ComponentChangeOrderReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private MaintenanceJobCardDataSet GenerateDataSet()

        private ComponentChangeOrderDataSet GenerateDataSet()
        {
            ComponentChangeOrderDataSet dataSet = new ComponentChangeOrderDataSet();
            AddAdditionalDataToDataSet(dataSet);
            AddMainInformationToDataSet(dataSet);
            AddAircraftToDataset(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddMainInformationToDataSet(ComponentChangeOrderDataSet destinationDataSet)

        private void AddMainInformationToDataSet(ComponentChangeOrderDataSet destinationDataSet)
        {
            foreach (Component detail in _currentDetails)
            {
                destinationDataSet.MainTable.AddMainTableRow(detail.ATAChapter.ToString(),
                                             _workType,
                                             detail.Description,
                                             detail.Manufacturer,
                                             detail.PartNumber,
                                             detail.SerialNumber,
                                             detail.Position,
                                             "",
                                             "",
                                             _currentWorkPackage.Title,
                                             _currentWorkPackage.Station,
                                             _orderNum.ToString());   
            }
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(ComponentChangeOrderDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(ComponentChangeOrderDataSet destinationDateSet)
        {
            var reportHeader = "Component Change Order";
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _currentWorkPackage.Aircraft.OperatorId).LogotypeReportLarge, reportHeader, "", "", "", reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region private void AddAircraftToDataset(ComponentChangeOrderDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(ComponentChangeOrderDataSet destinationDataSet)
        {
            if (_currentWorkPackage.Aircraft == null)
                return;
	        var aircraftLifelength =GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentWorkPackage.Aircraft);
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
