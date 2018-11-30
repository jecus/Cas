using System;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.WorkPackage;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчетов для списка директив
    /// </summary>
    public class WorkPackageReportBuilder : AbstractReportBuilder
    {

        #region Fields
        private Aircraft _reportedAircraft;
        private WorkPackage _reportedWorkPackage;
        private string _dateAsOf = "";
        private string _reportTitle = "Directive list report";

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            private get
            {
                return _reportedAircraft;
            }
            set
            {
                _reportedAircraft = value;
            }
        }

        #endregion
       
        #region public List<Directive> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public WorkPackage ReportedWorkPackage
        {
            set
            {
                _reportedWorkPackage = value;
            }
        }

        #endregion

        #region private string DateAsOf

        /// <summary>
        /// Текст поля DateAsOf
        /// </summary>
        private string DateAsOf
        {
            get { return _dateAsOf; }
            set { _dateAsOf = value; }
        }

        #endregion

        #region private string ReportTitle
        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        private string ReportTitle
        {
            get { return _reportTitle; }
        }

        #endregion

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            WorkPackageReport report = new WorkPackageReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual DirectiveListReportDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual WorkPackageDataSet GenerateDataSet()
        {
            WorkPackageDataSet dataset = new WorkPackageDataSet();
            AddAircraftToDataset(dataset);
            AddItemsToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
     
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(DirectiveListReportDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddItemsToDataSet(WorkPackageDataSet dataset)
        {
            int i;
            for (i = 0; i < _reportedWorkPackage.AdStatus.Count; i++)
                 AddADStatusItemToDataset(_reportedWorkPackage.AdStatus[i], dataset);
            for (i = 0; i < _reportedWorkPackage.Components.Count; i++)
                AddDetailItemToDataset(_reportedWorkPackage.Components[i], dataset);
        }

        #endregion

        #region protected void AddAircraftToDataset(Aircraft aircraft, DirectiveListReportDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddAircraftToDataset(WorkPackageDataSet destinationDataSet)
        {
    
            if (ReportedAircraft == null)
                return;
	        var aircraftLifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);
			string registrationNumber = ReportedAircraft.RegistrationNumber;
            string model = _reportedAircraft.Model.ToString();
            string serialNumber = ReportedAircraft.SerialNumber;
            string manufactureDate = SmartCore.Auxiliary.Convert.GetDateFormat(ReportedAircraft.ManufactureDate);
            string sinceNewHours = aircraftLifelength.Hours.ToString().Trim();
            string sinceNewCycles = aircraftLifelength.Cycles.ToString().Trim();
            string lineNumberCaption = "";
            string variableNumberCaption = "";

            string lineNumber = (ReportedAircraft).LineNumber;
            string variableNumber = (ReportedAircraft).VariableNumber;
            if (lineNumber != "")
                lineNumberCaption = "L/N:";
            if (variableNumber != "")
                variableNumberCaption = "V/N:";
            destinationDataSet.
                AircraftInformationTable.
                    AddAircraftInformationTableRow(registrationNumber, serialNumber, manufactureDate,
                                                   model, lineNumberCaption, variableNumberCaption,
                                                   lineNumber,variableNumber,sinceNewHours, sinceNewCycles);
        }

        #endregion

        #region public private void AddADStatusItemToDataset(BaseDetailDirective directive, DirectiveListReportDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="adStatusItem">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddADStatusItemToDataset(Directive adStatusItem, WorkPackageDataSet destinationDataSet)
        {
            GlobalObjects.PerformanceCalculator.GetNextPerformance(adStatusItem);

            string ataCapter = adStatusItem.ATAChapter.ToString();
            string reference = adStatusItem.Description;
            string description = adStatusItem.WorkType.ToString();
            string lastPerformance = (adStatusItem.LastPerformance == null ? "" : adStatusItem.LastPerformance.ToString());
            string mansHours = adStatusItem.ManHours.ToString();
            string overdue = (adStatusItem.Remains == null ? "" : adStatusItem.Remains.ToString());// ADStatusItem.ToString();
            string cost = adStatusItem.Cost.ToString();
            string approxDate = adStatusItem.NextPerformanceDate != null
                ? SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)adStatusItem.NextPerformanceDate)
                : "";

            const string groupName = "ADStatusItem";
            destinationDataSet.
                Items.
                    AddItemsRow(ataCapter, reference, description, "Work Type",
                                mansHours, groupName, cost, overdue, approxDate, lastPerformance);

        }

        #endregion

        #region public override void AddDetailItemToDataset(Detail componentStatus, WorkPackageDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент ServiceBulletin в таблицу данных
        /// </summary>
        /// <param name="componentStatus">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        public void AddDetailItemToDataset(Component componentStatus, WorkPackageDataSet destinationDataSet)
        {

            string groupName = "Detail";
            destinationDataSet.
                Items.
                    AddItemsRow("MyAtaChapter", "MyRefNo", "MyDescription", "MyWorkType",
                                "MyManHours", groupName, "Cost", "Overdue", "apdate", "Complitance");

        }

        #endregion

        #region protected void AddAdditionalDataToDataSet(WorkPackagesDataSet destinationDateSet, bool addRegistrationNumber)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected void AddAdditionalDataToDataSet(WorkPackageDataSet destinationDateSet)
        {
            var reportHeader = ReportedAircraft.RegistrationNumber + ". " + ReportTitle;
            DateAsOf = SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);

            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
        
            destinationDateSet.
                AdditionalDataTAble.
                    AddAdditionalDataTAbleRow(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogoTypeWhite,
                                              reportHeader, "MyDate", DateAsOf, 
                                              "MyMansHours", reportFooter, reportFooterPrepared, 
                                              reportFooterLink);

        }

        #endregion

        #endregion

    }
}