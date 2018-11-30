using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по Maintenance Status
    /// </summary>
    public class MaintenanceHistoryReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private List<MaintenanceCheckRecord> _reportedDirectives = new List<MaintenanceCheckRecord>();
        private ForecastData _forecastData;
        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "MAINTENANCE HISTORY";
        private bool _filterSelection;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;
        private Lifelength _current;
        private DateTime _manufactureDate;

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            get
            {
                return _reportedAircraft;
            }
            set
            {
                _reportedAircraft = value;
                if (value == null) return;
                _reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
                _manufactureDate = value.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogoTypeWhite;
            }
        }

        #endregion

        #region public BaseDetail ReportedBaseDetail

        /// <summary>
        /// Базовый агрегат, включаемый в отчет
        /// </summary>
        public BaseComponent ReportedBaseComponent
        {
            get
            {
                return _reportedBaseComponent;
            }
            set
            {
                if (value == null) return;
                _reportedBaseComponent = value;
                _manufactureDate = _reportedBaseComponent.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogoTypeWhite;
                _reportedDirectives.Clear();
                //  reportedDirectives.AddRange(GlobalObjects.CasEnvironment.Loader.GetDefferedItems(reportedBaseDetail));
            }
        }
        #endregion

        #region public List<MaintenanceCheckRecord> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<MaintenanceCheckRecord> ReportedDirectives
        {
            get
            {
                return _reportedDirectives;
            }
            set
            {
                _reportedDirectives = value;
            }
        }

        #endregion

        #region public string DateAsOf

        /// <summary>
        /// Текст поля DateAsOf
        /// </summary>
        public string DateAsOf
        {
            get { return _dateAsOf; }
            set { _dateAsOf = value; }
        }

        #endregion

        #region public string ReportTitle

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public string ReportTitle
        {
            get { return _reportTitle; }
            set { _reportTitle = value; }
        }

        #endregion

        #region public ForecastData ForecastData

        public ForecastData ForecastData
        {
            set { _forecastData = value; }
        }
        #endregion

        #region public public bool FilterSelection

        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public bool FilterSelection
        {
            get { return _filterSelection; }
            set { _filterSelection = value; }
        }

        #endregion
        /*#region public virtual DirectiveFilter DefaultFilter

        /// <summary>
        /// Фильтр по умолчанию
        /// </summary>
        public virtual DirectiveFilter DefaultFilter
        {
            get
            {
                return defaultFilter;
            }
        }

        #endregion*/

        #region public LifelengthFormatter LifelengthFormatter

        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        public LifelengthFormatter LifelengthFormatter
        {
            get { return _lifelengthFormatter; }
        }

        #endregion

        #region public Image OperatorLogotype

        /// <summary>
        /// Возвращает или устанавливает логтип эксплуатанта
        /// </summary>
        public byte[] OperatorLogotype
        {
            get
            {
                return _operatorLogotype;
            }
            set
            {
                _operatorLogotype = value;
            }
        }

        #endregion

        #region public Lifelength LifelengthAircraftSinceNew

        /// <summary>
        /// Наработка ВС SinceNew
        /// </summary>
        public Lifelength LifelengthAircraftSinceNew
        {
            get { return _lifelengthAircraftSinceNew; }
            set { _lifelengthAircraftSinceNew = value; }
        }

        #endregion

        #region public Lifelength LifelengthAircraftSinceOverhaul

        /// <summary>
        /// Наработка ВС SinceOverhaul
        /// </summary>
        public Lifelength LifelengthAircraftSinceOverhaul
        {
            get { return _lifelengthAircraftSinceOverhaul; }
            set { _lifelengthAircraftSinceOverhaul = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void AddDirectives(MaintenanceCheckRecord[] directives)

        public void AddDirectives(MaintenanceCheckRecord[] directives)
        {
            _reportedDirectives.Clear();
            _reportedDirectives.AddRange(directives);
            if (_reportedDirectives.Count == 0)
                return;

        }

        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MaintenanceHistoryReport report = new MaintenanceHistoryReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual MaintenanceHistoryDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual MaintenanceHistoryDataSet GenerateDataSet()
        {
            MaintenanceHistoryDataSet dataset = new MaintenanceHistoryDataSet();
            AddAircraftToDataset(dataset);
            //AddStatusToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            //AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(MaintenanceHistoryDataSet destinationDataSet)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(MaintenanceHistoryDataSet destinationDataSet)
        {                
            if (_reportedAircraft == null)
                return;
            var compliance = from item in _reportedDirectives
                             group item by item.NumGroup into compl
                             orderby compl.First().RecordDate descending
                             select compl;

            foreach (IGrouping<int, MaintenanceCheckRecord> grouping in compliance)
            {
                MaintenanceCheckRecord reportedDirective = grouping.First();
                string name = grouping.Aggregate("", (current, g) => current + (g.ParentCheck.Name + " "));

                Lifelength reportAircraftLifeLenght =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                Lifelength used = new Lifelength(reportAircraftLifeLenght);

                string lastComplianceDate = "", lastComplianceHours = "", lastComplianceCycles = "", lastComplianceDays = "";
                string remarks, references = "";


				remarks = reportedDirective.Remarks;
                lastComplianceDate = reportedDirective.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                lastComplianceCycles = reportedDirective.OnLifelength.Cycles != null
                                               ? reportedDirective.OnLifelength.Cycles.ToString()
                                               : "";
                lastComplianceHours = reportedDirective.OnLifelength.Hours != null
                                               ? reportedDirective.OnLifelength.Hours.ToString()
                                               : "";
                lastComplianceDays = reportedDirective.OnLifelength.Days != null
                                               ? reportedDirective.OnLifelength.Days.ToString()
                                               : "";

	            var unusedDays = reportedDirective.Unused?.Days.ToString() ?? "";
				var unusedHours = reportedDirective.Unused?.Hours.ToString() ?? "";
				var unusedCycles = reportedDirective.Unused?.Cycles.ToString() ?? "";
				var overusedDays = reportedDirective.Overused?.Days.ToString() ?? "";
				var overusedHours = reportedDirective.Overused?.Hours.ToString() ?? "";
				var overusedCycles = reportedDirective.Overused?.Cycles.ToString() ?? "";

				used.Substract(reportedDirective.OnLifelength);
                destinationDataSet.ItemsTable.AddItemsTableRow(lastComplianceDate,
                                                               reportedDirective.NumGroup,
                                                               reportedDirective.ParentCheck.Schedule ? "SCHEDULE" : "UNSCHEDULE",
                                                               name,
                                                               lastComplianceDays,
                                                               lastComplianceHours,
                                                               lastComplianceCycles,
															   unusedDays,
															   unusedHours,
															   unusedCycles,
															   overusedDays,
															   overusedHours,
															   overusedCycles,
                                                               remarks,
                                                               references);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(MaintenanceHistoryDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MaintenanceHistoryDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = ReportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ToString();
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var registrationNumber = ReportedAircraft.RegistrationNumber;
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if (_forecastData == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = (int)averageUtilization.Hours;
                averageUtilizationCycles = (int)averageUtilization.Cycles;
                averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
            }
            else
            {
                averageUtilizationHours = (int)_forecastData.AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecastData.AverageUtilization.Cycles;
                averageUtilizationType =
                    _forecastData.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }

            var lineNumber = (ReportedAircraft).LineNumber;
            var variableNumber = (ReportedAircraft).VariableNumber;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(MaintenanceHistoryDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MaintenanceHistoryDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, _filterSelection?"Schedule":"Unschedule", DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #endregion

    }
}