using System;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по Maintenance Status
    /// </summary>
    public class MaintenanceStatusReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private MaintenanceCheckCollection _reportedDirectives = new MaintenanceCheckCollection();
        private ForecastData _forecastData;
        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "MAINTENANCE STATUS";
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
            }
        }
        #endregion

        #region public MaintenanceCheckCollectionReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public MaintenanceCheckCollection ReportedDirectives
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

        #region public void AddDirectives(MaintenanceCheck[] directives)

        public void AddDirectives(MaintenanceCheck[] directives)
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
            MaintenanceStatusReport report = new MaintenanceStatusReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual MaintenanceStatusDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual MaintenanceStatusDataSet GenerateDataSet()
        {
            MaintenanceStatusDataSet dataset = new MaintenanceStatusDataSet();
            AddAircraftToDataset(dataset);
            AddStatusToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(MaintenanceStatusDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(MaintenanceStatusDataSet dataset)
        {
            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(_reportedDirectives, _filterSelection);

            foreach (MaintenanceCheck t in _reportedDirectives)
            {
                var hiddenRemark = "";
                Lifelength lastCompliance = Lifelength.Null,
                           repeatInterval = Lifelength.Null;
                var lastComplianceDate = "";
                var used = Lifelength.Null;

                var remarks = t.LastPerformance != null ? t.LastPerformance.Remarks : "";
                //расчет остатка от выполнения с даты производтсва
                var next = t.NextPerformanceSource;
                var remains = t.Remains;
                var condition = t.Condition;

                if (t.LastPerformance != null)
                {
                    if (t.Interval != null) repeatInterval = t.Interval;

                    lastComplianceDate = t.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
	                lastCompliance = t.LastPerformance.OnLifelength;
					used.Add(_current);
                    used.Substract(lastCompliance);
                }
                var nextComplianceDate = t.NextPerformanceDate != null
                                                ? ((DateTime)t.NextPerformanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                                                : "";

                dataset.ItemsTable.AddItemsTableRow(remarks,
                                                    hiddenRemark,
                                                    "",
                                                    t.Name,
                                                    repeatInterval.Days != null ? repeatInterval.Days.ToString() : "",
                                                    repeatInterval.Hours != null ? repeatInterval.Hours.ToString() : "",
                                                    repeatInterval.Cycles != null ? repeatInterval.Cycles.ToString() : "",
                                                    lastComplianceDate,
                                                    lastCompliance.Hours != null ? lastCompliance.Hours.ToString() : "",
                                                    lastCompliance.Cycles != null ? lastCompliance.Cycles.ToString() : "",
                                                    used.Days != null ? used.Days.ToString() : "",
                                                    used.Hours != null ? used.Hours.ToString() : "",
                                                    used.Cycles != null ? used.Cycles.ToString() : "",
                                                    nextComplianceDate,
                                                    next.Hours != null ? next.Hours.ToString() : "",
                                                    next.Cycles != null ? next.Cycles.ToString() : "",
                                                    remains.Days != null ? remains.Days.ToString() : "",
                                                    remains.Hours != null ? remains.Hours.ToString() : "",
                                                    remains.Cycles != null ? remains.Cycles.ToString() : "",
                                                    condition.ToString());
            }
        }

        #endregion

        #region private void AddAircraftToDataset(MaintenanceStatusDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MaintenanceStatusDataSet destinationDataSet)
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

        #region private void AddStatusToDataset(MaintenanceStatusDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddStatusToDataset(MaintenanceStatusDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            MaintenanceCheckComplianceGroup lastComplianceGroup =
                _reportedDirectives.GetLastComplianceCheckGroup(_filterSelection, _reportedAircraft.ItemId);
            MaintenanceCheckGroupByType nextComplianceGroup =
                GlobalObjects.MaintenanceCheckCalculator.GetNextCheckComplianceGroup(_reportedDirectives, _filterSelection, _reportedAircraft);
            MaintenanceCheck minStepCheck = _reportedDirectives != null
                                                ? _reportedDirectives.GetMinStepCheck(_filterSelection)
                                                : null;
            Lifelength reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
            Lifelength minStep = minStepCheck != null ? minStepCheck.Interval : Lifelength.Null;
            Lifelength used = new Lifelength(reportAircraftLifeLenght);
            Lifelength remain = Lifelength.Null;
            
            string lastComplianceDate = "", lastComplianceHours = "", lastComplianceCycles = "";
            string nextComplianceDate = "", nextComplianceHours = "", nextComplianceCycles = "";
            string remarks = "";
            if(lastComplianceGroup != null)
            {
                lastComplianceDate = lastComplianceGroup.LastGroupComplianceDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                lastComplianceCycles = lastComplianceGroup.LastGroupComplianceLifelength.Cycles != null
                                           ? lastComplianceGroup.LastGroupComplianceLifelength.Cycles.ToString()
                                           : "";
                lastComplianceHours = lastComplianceGroup.LastGroupComplianceLifelength.Hours != null
                                           ? lastComplianceGroup.LastGroupComplianceLifelength.Hours.ToString()
                                           : "";
                used.Substract(lastComplianceGroup.LastGroupComplianceLifelength);
                remarks = lastComplianceGroup.Remarks;
            }
            if (nextComplianceGroup != null)
            {
                nextComplianceDate = nextComplianceGroup.GroupComplianceDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                nextComplianceCycles = nextComplianceGroup.GroupComplianceLifelength.Cycles != null
                                           ? nextComplianceGroup.GroupComplianceLifelength.Cycles.ToString()
                                           : "";
                nextComplianceHours = nextComplianceGroup.GroupComplianceLifelength.Hours != null
                                           ? nextComplianceGroup.GroupComplianceLifelength.Hours.ToString()
                                           : "";
                remain.Add(nextComplianceGroup.GroupComplianceLifelength);
                remain.Substract(reportAircraftLifeLenght);
            }

            string usedHours = used.Hours != null ? used.Hours.ToString() : "";
            string usedCycles = used.Cycles != null ? used.Cycles.ToString() : "";
            string usedDays = used.Days != null ? used.Days.ToString() : "";
            string remainHours = remain.Hours != null ? remain.Hours.ToString() : "";
            string remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "";
            string remainDays = remain.Days != null ? remain.Days.ToString() : "";

            destinationDataSet.StatusTable.AddStatusTableRow(_filterSelection ? "Schedule" : "Unschedule",
                                                             lastComplianceGroup != null
                                                                ? lastComplianceGroup.ToStringCheckNames()
                                                                : "",
                                                             nextComplianceGroup != null
                                                                ? nextComplianceGroup.ToStringCheckNames()
                                                                : "",
                                                             minStep.Hours != null ? minStep.Hours.ToString() : "",
                                                             minStep.Cycles != null ? minStep.Cycles.ToString() : "",
                                                             minStep.Days != null ? minStep.Days.ToString() : "",
                                                             lastComplianceDate,
                                                             lastComplianceHours,
                                                             lastComplianceCycles,
                                                             usedDays,
                                                             usedHours,
                                                             usedCycles,
                                                             nextComplianceDate,
                                                             nextComplianceHours,
                                                             nextComplianceCycles,
                                                             remainDays,
                                                             remainHours,
                                                             remainCycles,
                                                             remarks);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(MaintenanceStatusDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MaintenanceStatusDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, _filterSelection?"Schedule":"Unschedule", DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(MaintenanceStatusDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(MaintenanceStatusDataSet destinationDataSet)
        {
            var avgUtilizationCycles = _forecastData != null ? _forecastData.AverageUtilization.Cycles : 0;
            var avgUtilizationHours = _forecastData != null ? _forecastData.AverageUtilization.Hours : 0;
            var avgUtilizationType = _forecastData != null
                                            ? _forecastData.AverageUtilization.SelectedInterval.ToString()
                                            : "";
            var forecastCycles = _forecastData != null
                ? _forecastData.ForecastLifelength.Cycles != null ? (int)_forecastData.ForecastLifelength.Cycles : 0
                : 0;
            var forecastHours = _forecastData != null
                ? _forecastData.ForecastLifelength.Hours != null ? (int)_forecastData.ForecastLifelength.Hours : 0
                : 0;
            var forecastDays = _forecastData != null
                ? _forecastData.ForecastLifelength.Days != null ? (int)_forecastData.ForecastLifelength.Days : 0
                : 0;
            var forecastDate = _forecastData != null
                ? _forecastData.ForecastDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                : "";
            destinationDataSet.ForecastTable.AddForecastTableRow(avgUtilizationCycles,
                                                                 avgUtilizationHours,
                                                                 avgUtilizationType,
                                                                 forecastCycles,
                                                                 forecastHours,
                                                                 forecastDays,
                                                                 forecastDate);
        }

        #endregion

        #endregion

    }
}