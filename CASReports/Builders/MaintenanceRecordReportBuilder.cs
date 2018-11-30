using System;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по Maintenance Status
    /// </summary>
    public class MaintenanceRecordReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private MaintenanceCheckCollection _reportedDirectives = new MaintenanceCheckCollection();
        private ForecastData _forecastData;
        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "MAINTENANCE RECORD";
        private bool _filterSelection;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;
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
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
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
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
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
            MaintenanceRecordReport report = new MaintenanceRecordReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual MaintenanceRecordDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual MaintenanceRecordDataSet GenerateDataSet()
        {
            var dataset = new MaintenanceRecordDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(MaintenanceRecordDataSet destinationDataSet)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(MaintenanceRecordDataSet destinationDataSet)
        {
            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(_reportedDirectives, true);
            GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(_reportedDirectives, false);
            
            int checkId = 0;
            foreach (var reportedDirective in _reportedDirectives)
            {
                if (_reportedAircraft == null)
                    return;
                checkId++;
                var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                var minStep = reportedDirective.Interval;
                var used = new Lifelength(reportAircraftLifeLenght);

                string lastComplianceDate = "", lastComplianceHours = "", lastComplianceCycles = "";
                string nextComplianceDate = "", nextComplianceHours = "", nextComplianceCycles = "";
                double costTotal = 0, mhTotal = 0;

                var remarks = reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.Remarks : "";

                foreach (AccessoryRequired kit in reportedDirective.Kits)
                {
                    costTotal += kit.Quantity * kit.CostNew;
                    destinationDataSet.FinancesTable.AddFinancesTableRow(remarks,
                                                               kit.Description,
                                                               reportedDirective.Schedule ? checkId : 1000+checkId,
                                                               "KIT",
                                                               0,
                                                               kit.Quantity,
                                                               0,
                                                               kit.CostNew);

                    destinationDataSet.EquipmentTable.AddEquipmentTableRow(remarks,
                                                               kit.Description,
                                                               reportedDirective.Schedule ? checkId : 1000+checkId,
                                                               "KIT",
                                                               0,
                                                               "",
                                                               kit.PartNumber);
                }


                remarks = ""; string hiddenRemarks = "";
                if (reportedDirective.LastPerformance != null)
                {
                    lastComplianceDate = reportedDirective.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                    lastComplianceCycles = reportedDirective.LastPerformance.OnLifelength.Cycles != null
                                               ? reportedDirective.LastPerformance.OnLifelength.Cycles.ToString()
                                               : "";
                    lastComplianceHours = reportedDirective.LastPerformance.OnLifelength.Hours != null
                                               ? reportedDirective.LastPerformance.OnLifelength.Hours.ToString()
                                               : "";
                    used.Substract(reportedDirective.LastPerformance.OnLifelength);
                    remarks = reportedDirective.LastPerformance.Remarks;
                    hiddenRemarks = reportedDirective.LastPerformance.Remarks;
                }
                var next = reportedDirective.NextPerformanceSource;
                var remains = reportedDirective.Remains;

                string usedHours = "", usedCycles = "", usedDays = "",
                       remainHours = "", remainCycles = "", remainDays = "";
                if (reportedDirective.NextPerformanceDate != null)
                {
                    nextComplianceDate = ((DateTime)reportedDirective.NextPerformanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                    nextComplianceCycles = next.Cycles != null
                                               ? next.Cycles.ToString()
                                               : "";
                    nextComplianceHours = next.Hours != null
                                               ? next.Hours.ToString()
                                               : "";
                    usedHours = used.Hours != null ? used.Hours.ToString() : "";
                    usedCycles = used.Cycles != null ? used.Cycles.ToString() : "";
                    usedDays = used.Days != null ? used.Days.ToString() : "";
                    remainHours = remains.Hours != null ? remains.Hours.ToString() : "";
                    remainCycles = remains.Cycles != null ? remains.Cycles.ToString() : "";
                    remainDays = remains.Days != null ? remains.Days.ToString() : "";
                }
                destinationDataSet.StatusTable.AddStatusTableRow(reportedDirective.Schedule ? checkId : 1000 + checkId,
                                                                 reportedDirective.Name + (reportedDirective.Schedule ? " Schedule" : " Unschedule"),
                                                                 costTotal,
                                                                 mhTotal,
                                                                 reportedDirective.CheckType.ToString(),
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
                                                                 remarks,
                                                                 hiddenRemarks);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(MaintenanceRecordDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MaintenanceRecordDataSet destinationDataSet)
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

        #region private void AddAdditionalDataToDataSet(MaintenanceRecordDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MaintenanceRecordDataSet destinationDateSet)
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