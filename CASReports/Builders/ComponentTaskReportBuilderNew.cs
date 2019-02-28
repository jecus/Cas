using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using TempUIExtentions;

namespace CASReports.Builders
{
    public class ComponentTasksReportBuilderNew : AbstractReportBuilder
    {


	    #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Component _reportedComponent;
        private List<object> _reportedDirectives = new List<object>();
        private ForecastData _forecastData;

        private string _dateAsOf = "";
        private string _reportTitle;
        private readonly string _thrust;
		private string _filterSelection;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;
        private Lifelength _current;
        private DateTime _manufactureDate;

        #endregion

        #region Properties

        #region public Detail ReportedDetail

        /// <summary>
        /// Базовый агрегат, включаемый в отчет
        /// </summary>
        public Component ReportedComponent
        {
            get
            {
                return _reportedComponent;
            }
            set
            {
                if (value == null) return;
                _reportedComponent = value;
                _manufactureDate = _reportedComponent.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedComponent);
                _reportedDirectives.Clear();
            }
        }
        #endregion

        #region public List<object> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<object> ReportedDirectives
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

        #region public string ReportTitle
        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public string FilterSelection
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

        public ComponentTasksReportBuilderNew(string title, string thrust)
        {
	        _thrust = thrust;
	        _reportTitle = title + "  RECORD";
        }

        #region Methods

        #region public void AddDirectives(object[] directives)

        public void AddDirectives(object[] directives)
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
            var report = new DirectiveTaskReportNew();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual DirectivesListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual DirectivesListDataSet GenerateDataSet()
        {
            var dataset = new DirectivesListDataSet();
            AddBaseDetailToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(DirectivesListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(DirectivesListDataSet dataset)
        {
            foreach (var t in _reportedDirectives)
                AddDirectiveToDataset(t, dataset);
        }

        #endregion

        #region private void AddAircraftToDataset(DirectivesListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(DirectivesListDataSet destinationDataSet)
        {
            if (_reportedComponent == null)
                return;
            BaseComponent baseComponent;
            Aircraft parentAircaft;
            DateTime installationDate;
            string position;
            Lifelength reportAircraftLifeLenght;

	        parentAircaft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedComponent.ParentAircraftId);
	        var lastTransferRecord = _reportedComponent.TransferRecords.GetLast();
			installationDate = lastTransferRecord.TransferDate;
            position = lastTransferRecord.Position;

            if(_reportedComponent.IsBaseComponent)
            {
                baseComponent =
                    GlobalObjects.ComponentCore.GetBaseComponentById(_reportedComponent.ItemId);
                reportAircraftLifeLenght =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(baseComponent);
            }
            else
            {
                reportAircraftLifeLenght =
                    GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedComponent);
            }
            var manufactureDate = _reportedComponent.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var deliveryDate = _reportedComponent.DeliveryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var status = _reportedComponent.ComponentStatus;
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var sinceNewDays = reportAircraftLifeLenght.Days != null ? reportAircraftLifeLenght.Days.ToString() : "";
            
            var lifeLimit = _reportedComponent.LifeLimit;
            var lifeLimitHours = lifeLimit.Hours != null && lifeLimit.Hours != 0 ? lifeLimit.Hours.ToString() : "";
			var lifeLimitCycles = lifeLimit.Cycles != null && lifeLimit.Cycles != 0 ? lifeLimit.Cycles.ToString() : "";
			var lifeLimitDays = lifeLimit.Days != null && lifeLimit.Days != 0 ? lifeLimit.Days.ToString() : "";
			var remain = Lifelength.Null;
            if(!lifeLimit.IsNullOrZero())
            {
                remain.Add(lifeLimit);
                remain.Substract(reportAircraftLifeLenght); 
                remain.Resemble(lifeLimit);
            }
			var remainHours = remain.Hours != null && remain.Hours != 0 ? remain.Hours.ToString() : "";
			var remainCycles = remain.Cycles != null && remain.Cycles != 0 ? remain.Cycles.ToString() : "";
			var remainDays = remain.Days != null && remain.Days != 0 ? remain.Days.ToString() : "";
			var onInstall = lastTransferRecord.OnLifelength;
			var onInstallDate = installationDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var onInstallHours = onInstall.Hours != null && onInstall.Hours != 0 ? onInstall.Hours.ToString() : "";
			var onInstallCycles = onInstall.Cycles != null && onInstall.Cycles != 0 ? onInstall.Cycles.ToString() : "";
			var onInstallDays = onInstall.Days != null && onInstall.Days != 0 ? onInstall.Days.ToString() : "";
			var sinceInstall = new Lifelength(reportAircraftLifeLenght);
            sinceInstall.Substract(onInstall);
			var sinceInstallHours = sinceInstall.Hours != null && sinceInstall.Hours != 0 ? sinceInstall.Hours.ToString() : "";
			var sinceInstallCycles = sinceInstall.Cycles != null && sinceInstall.Cycles != 0 ? sinceInstall.Cycles.ToString() : "";
			var sinceInstallDays = sinceInstall.Days != null && sinceInstall.Days != 0 ? sinceInstall.Days.ToString() : "";
			var warranty = _reportedComponent.Warranty;
			var warrantyRemain = new Lifelength(warranty);
            warrantyRemain.Substract(reportAircraftLifeLenght);
            warrantyRemain.Resemble(warranty);
			var warrantyHours = warranty.Hours != null && warranty.Hours != 0 ? warranty.Hours.ToString() : "";
			var warrantyCycles = warranty.Cycles != null && warranty.Cycles != 0 ? warranty.Cycles.ToString() : "";
			var warrantyDays = warranty.Days != null && warranty.Days != 0 ? warranty.Days.ToString() : "";
			var warrantyRemainHours = warrantyRemain.Hours != null && warrantyRemain.Hours != 0 ? warrantyRemain.Hours.ToString() : "";
			var warrantyRemainCycles = warrantyRemain.Cycles != null && warrantyRemain.Cycles != 0 ? warrantyRemain.Cycles.ToString() : "";
			var warrantyRemainDays = warrantyRemain.Days != null && warrantyRemain.Days != 0 ? warrantyRemain.Days.ToString() : "";
            Lifelength aircraftOnInstall, aircraftCurrent = Lifelength.Null;
			var aircraftOnInstallHours = "";
			var aircraftOnInstallCycles = "";
			var aircraftOnInstallDays = "";
			var aircraftCurrentHours = 0;
			var aircraftCurrentCycles = 0;
			var aircraftReNumString = "";
            if(parentAircaft != null)
            {
                aircraftReNumString = _reportedComponent.GetParentAircraftRegNumber();
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
				aircraftOnInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, installationDate);
				aircraftOnInstallHours = aircraftOnInstall.Hours != null ? aircraftOnInstall.Hours.ToString() : "";
                aircraftOnInstallCycles = aircraftOnInstall.Cycles != null ? aircraftOnInstall.Cycles.ToString() : "";
                aircraftOnInstallDays = aircraftOnInstall.Days != null ? aircraftOnInstall.Days.ToString() : "";
                aircraftCurrent = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircaft);
            }
            Lifelength sinceOverhaul = Lifelength.Null;
			var lastOverhaulDate = DateTime.MinValue;
			var lastOverhaulDateString = "";

			var model = "";
			if (_reportedComponent.Model != null)
			{
				if (_reportedComponent.IsBaseComponent)
				{
					var bc = _reportedComponent as BaseComponent;
					if (bc.BaseComponentType == BaseComponentType.LandingGear || bc.BaseComponentType == BaseComponentType.Engine)
						model = _reportedComponent.Model.FullName;
					else model = _reportedComponent.Model.FullName;
				}
				else model = _reportedComponent.Model.FullName;
			}


			#region поиск последнего ремонта и расчет времени, прошедшего с него
			//поиск директив деталей
			var directives = 
                new List<ComponentDirective>(_reportedComponent.ComponentDirectives.ToArray());
			//поиск директивы ремонта
			var overhauls =
                directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
            //поиск последнего ремонта
            ComponentDirective lastOverhaul = null;
            foreach(var d in overhauls)
            {
                if (d.LastPerformance == null || d.LastPerformance.RecordDate <= lastOverhaulDate) continue;
                
                lastOverhaulDate = d.LastPerformance.RecordDate;
                lastOverhaul = d;
            }

            if(lastOverhaul != null)
            {
                sinceOverhaul.Add(reportAircraftLifeLenght);
                sinceOverhaul.Substract(lastOverhaul.LastPerformance.OnLifelength);
                lastOverhaulDateString = lastOverhaul.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            }

            #endregion

            destinationDataSet.BaseDetailTable.AddBaseDetailTableRow(_reportedComponent.ATAChapter.ToString(),
                                                                     _reportedComponent.AvionicsInventory.ToString(),
                                                                     _reportedComponent.PartNumber,
                                                                     _reportedComponent.SerialNumber,
                                                                     model,
                                                                     _reportedComponent.Model?.Description,
                                                                     aircraftReNumString,
                                                                     position,
                                                                     _reportedComponent.Manufacturer,
                                                                     manufactureDate,
                                                                     deliveryDate,
                                                                     _reportedComponent.MPDItem,
                                                                     _reportedComponent.Suppliers != null
                                                                        ? _reportedComponent.Suppliers.ToString()
                                                                        : "",
                                                                     status.ToString(),
                                                                     _reportedComponent.Cost,
                                                                     _reportedComponent.CostOverhaul,
                                                                     _reportedComponent.CostServiceable,
                                                                     lifeLimitHours,
                                                                     lifeLimitCycles,
                                                                     lifeLimitDays,
                                                                     sinceNewHours,
                                                                     sinceNewCycles,
                                                                     sinceNewDays,
                                                                     remainCycles,
                                                                     remainHours,
                                                                     remainDays,
                                                                     onInstallDate,
                                                                     onInstallHours,
                                                                     onInstallCycles,
                                                                     onInstallDays,
                                                                     sinceInstallHours,
                                                                     sinceInstallCycles,
                                                                     sinceInstallDays,
                                                                     warrantyHours,
                                                                     warrantyCycles,
                                                                     warrantyDays,
                                                                     warrantyRemainHours,
                                                                     warrantyRemainCycles,
                                                                     warrantyRemainDays,
                                                                     aircraftOnInstallHours,
                                                                     aircraftOnInstallCycles,
                                                                     aircraftOnInstallDays,
                                                                     lastOverhaulDateString,
                                                                     sinceOverhaul.Hours ?? 0,
                                                                     sinceOverhaul.Cycles ?? 0);

            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if (_forecastData == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = parentAircaft!=null?(int)averageUtilization.Hours:0;
                averageUtilizationCycles = parentAircaft!=null?(int)averageUtilization.Cycles:0;
                averageUtilizationType =
                    parentAircaft!=null? averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month" : "";
            }
            else
            {
                averageUtilizationHours = (int)_forecastData.AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecastData.AverageUtilization.Cycles;
                averageUtilizationType =
                    _forecastData.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow("",
                                                                         manufactureDate,
                                                                         aircraftCurrent.ToHoursMinutesFormat(""),
                                                                         aircraftCurrent.Cycles != null && aircraftCurrent.Cycles != 0 
                                                                            ? aircraftCurrent.Cycles.ToString() 
                                                                            : "",
                                                                         "", "", "", "",
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        
        }

        #endregion

        #region public void AddDirectiveToDataset(object directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedDirective">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(object reportedDirective, DirectivesListDataSet destinationDataSet)
        {
	        var detailDirective = (ComponentDirective) reportedDirective;
	        var detail = detailDirective.ParentComponent;

			var references = "";

			var title = "";
			var eo = "";
			var sb = "";
			var remarks = detailDirective.LastPerformance != null ? detailDirective.LastPerformance.Remarks : detail.Remarks;

            
            string status = "";
            if (detailDirective.Status == DirectiveStatus.Closed) status = "C";
            if (detailDirective.Status == DirectiveStatus.Open) status = "O";
            if (detailDirective.Status == DirectiveStatus.Repetative) status = "R";
            if (detailDirective.Status == DirectiveStatus.NotApplicable) status = "N/A";
            //string effectivityDate = UsefulMethods.NormalizeDate(detailDirective.Threshold.);
            string equipment = "";//detailDirective.NonDestructiveTest ? "NDT" : "";
            string kits = "";
            int num = 1;
            foreach (var kit in detailDirective.Kits)
            {
                kits += num + ": " + kit.PartNumber + "\n";
                num++;
            }

            //расчет остатка с даты производства и с эффективной даты
            Lifelength sinceNewThreshold = Lifelength.Null, sinceEffDateThreshold = Lifelength.Null;
            Lifelength sinceNewRemain = Lifelength.Null, sinceEffDateRemain = Lifelength.Null;

            Lifelength firstCompliance = Lifelength.Null,
                       lastCompliance = Lifelength.Null,
                       repeatInterval = Lifelength.Null,
                       nextCompliance,
                       remain = Lifelength.Null;
            string firstComplianceDate = "", 
                   lastComplianceDate = "", 
                   nextComplianceDate,
                   sinceNewComplianceDate = "";
            Lifelength used = Lifelength.Null;

            if (detailDirective.Threshold.FirstPerformanceSinceNew != null)
            {
                sinceNewThreshold = detailDirective.Threshold.FirstPerformanceSinceNew;
                if (sinceNewThreshold.Days != null)
                {
                    sinceNewComplianceDate =
                        _manufactureDate.AddDays(sinceNewThreshold.Days.Value).ToString(
                            new GlobalTermsProvider()["DateFormat"].ToString());
                }
                if (detailDirective.LastPerformance == null)
                {
                    sinceNewRemain.Add(detailDirective.Threshold.FirstPerformanceSinceNew);
                    sinceNewRemain.Substract(_current);
                    sinceNewRemain.Resemble(detailDirective.Threshold.FirstPerformanceSinceNew);
                }
            }

            GlobalObjects.PerformanceCalculator.GetNextPerformance(detailDirective);
            if (detailDirective.LastPerformance != null)
            {
                firstComplianceDate =
                    detailDirective.PerformanceRecords[0].RecordDate.ToString(
                        new GlobalTermsProvider()["DateFormat"].ToString());
                firstCompliance = detailDirective.PerformanceRecords[0].OnLifelength;

                if (detailDirective.Threshold.RepeatInterval != null) repeatInterval = detailDirective.Threshold.RepeatInterval;

                lastComplianceDate =
                    detailDirective.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                lastCompliance = detailDirective.LastPerformance.OnLifelength;

                used.Add(_current);
                used.Substract(detailDirective.LastPerformance.OnLifelength);

                if (detailDirective.NextPerformanceSource != null)
                {
                    remain.Add(detailDirective.NextPerformanceSource);
                    remain.Substract(_current);
                    remain.Resemble(detailDirective.Threshold.RepeatInterval);
                }
            }
            else
            {
	            repeatInterval = detailDirective.Threshold.RepeatInterval;
            }

            nextComplianceDate = detailDirective.NextPerformanceDate != null
                                     ? ((DateTime)detailDirective.NextPerformanceDate).ToString(
                                         new GlobalTermsProvider()["DateFormat"].ToString())
                                     : "";
            nextCompliance = detailDirective.NextPerformanceSource ?? Lifelength.Null;

			var condition = detailDirective.Condition.ToString();

            destinationDataSet.ItemsTable.AddItemsTableRow("Applicability",
                                                           remarks,
                                                           detail.HiddenRemarks,
                                                           detail.Description,
                                                           title,
                                                           references,
                                                           detailDirective.DirectiveType.ToString(),
                                                           status,
                                                           "",
                                                           sinceNewThreshold.Hours ?? 0,
                                                           sinceNewThreshold.Cycles ?? 0,
                                                           sinceNewComplianceDate,
                                                           detailDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L",
                                                           sinceNewRemain.Hours ?? 0,
                                                           sinceNewRemain.Cycles ?? 0,
                                                           sinceNewRemain.Days ?? 0,
                                                           sinceEffDateThreshold.Hours ?? 0,
                                                           sinceEffDateThreshold.Cycles ?? 0,
                                                           sinceEffDateThreshold.Days != null ? sinceEffDateThreshold.Days.ToString() : "",
                                                           detailDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L",
                                                           sinceEffDateRemain.Hours ?? 0,
                                                           sinceEffDateRemain.Cycles ?? 0,
                                                           sinceEffDateRemain.Days ?? 0,
                                                           firstComplianceDate,
                                                           firstCompliance.Hours ?? 0,
                                                           firstCompliance.Cycles ?? 0,
                                                           firstCompliance.ToStrings(),
                                                           repeatInterval.Days ?? 0,
                                                           repeatInterval.Hours ?? 0,
                                                           repeatInterval.Cycles ?? 0, 
                                                           repeatInterval.ToStrings(),
                                                           lastComplianceDate,
                                                           lastCompliance.Hours ?? 0,
                                                           lastCompliance.Cycles ?? 0,
                                                           lastCompliance.ToStrings(),
                                                           sinceNewThreshold.Days ?? 0,
                                                           firstCompliance.Days ?? 0,
                                                           lastCompliance.Days ?? 0,
                                                           nextComplianceDate,
                                                           nextCompliance.Hours ?? 0,
                                                           nextCompliance.Cycles ?? 0,
                                                           nextCompliance.ToStrings(),
                                                           remain.Days != null ? remain.Days.ToString() : "",
                                                           remain.Hours ?? 0,
                                                           remain.Cycles ?? 0,
                                                           remain.ToStrings(),
                                                           condition,
                                                           detailDirective.ManHours,
                                                           nextCompliance.Days ?? 0,
                                                           kits,
                                                           equipment,
                                                           detail.ATAChapter.ShortName,
                                                           detail.ATAChapter.FullName,
                                                           "",
                                                           sb,
                                                           eo != "" ?'(' + eo + ')' : "", "", "");
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)
        {
			var firsttitle = "";
			var discriptiontitle = "";
			var secondtitle = "";

			var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, _filterSelection, DateAsOf, firsttitle, discriptiontitle, secondtitle, reportFooter, reportFooterPrepared, _thrust);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)
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
