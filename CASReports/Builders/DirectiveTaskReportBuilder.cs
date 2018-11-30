using System;
using System.Collections.Generic;
using System.Linq;
using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CASReports.Builders
{
    public class DirectiveTasksReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private List<Directive> _reportedDirectives = new List<Directive>();
        private ForecastData _forecastData;
        private DirectiveType _directiveType = DirectiveType.AirworthenessDirectives;

        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "AD STATUS";
        private string _filterSelection;
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
            set
            {
                _reportedAircraft = value;
                if(value == null)return;
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

        public DirectiveType DirectiveType
        {
            set { _directiveType = value; }
        }
        #endregion

        #region public List<Directive> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<Directive> ReportedDirectives
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

        #region public void AddDirectives(IEnumerable<Directive> directives)

        public void AddDirectives(IEnumerable<Directive> directives)
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
            DirectiveTaskReport report = new DirectiveTaskReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private DirectivesListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        private DirectivesListDataSet GenerateDataSet()
        {
            DirectivesListDataSet dataset = new DirectivesListDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region private void AddDirectivesToDataSet(DirectivesListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddDirectivesToDataSet(DirectivesListDataSet dataset)
        {
            foreach (Directive t in _reportedDirectives)
            {
                AddDirectiveToDataset(t, dataset);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(DirectivesListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(DirectivesListDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ToString();
	        var registrationNumber = _reportedAircraft.RegistrationNumber;
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

            var lineNumber = _reportedAircraft.LineNumber;
            var variableNumber = _reportedAircraft.VariableNumber;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
                                                                         manufactureDate,
                                                                         reportAircraftLifeLenght.ToHoursMinutesFormat(""),
                                                                         reportAircraftLifeLenght.Cycles != null && reportAircraftLifeLenght.Cycles != 0
                                                                            ? reportAircraftLifeLenght.Cycles.ToString()
                                                                            : "",
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddAircraftToDataset(DirectivesListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(DirectivesListDataSet destinationDataSet)
        {
            if (_reportedAircraft != null)
                return;
	        var parentAircaft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
	        var parentStore = GlobalObjects.StoreCore.GetStoreById(_reportedBaseComponent.ParentStoreId);
			var reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
	        var regNumber = _reportedBaseComponent.GetParentAircraftRegNumber();
			var location = !string.IsNullOrEmpty(regNumber)
                                  ? regNumber
								  : parentStore != null ? parentStore.Name : "";
			var manufactureDate = _reportedBaseComponent.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var deliveryDate = _reportedBaseComponent.DeliveryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var status = _reportedBaseComponent.Serviceable ? "Serviceable" : "Unserviceable";
			var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
			var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
			var sinceNewDays = reportAircraftLifeLenght.Days != null ? reportAircraftLifeLenght.Days.ToString() : "";

			var lifeLimit = _reportedBaseComponent.LifeLimit;
			var lifeLimitHours = lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "";
			var lifeLimitCycles = lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "";
			var lifeLimitDays = lifeLimit.Days != null ? lifeLimit.Days.ToString() : "";
			var remain = Lifelength.Null;
            if(!lifeLimit.IsNullOrZero())
            {
                remain.Add(lifeLimit);
                remain.Substract(reportAircraftLifeLenght); 
                remain.Resemble(lifeLimit);
            }
			var remainHours = remain.Hours != null ? remain.Hours.ToString() : "";
			var remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "";
			var remainDays = remain.Days != null ? remain.Days.ToString() : "";
	        var lastTransferRecord = _reportedBaseComponent.TransferRecords.GetLast();
			var installationDate = lastTransferRecord.TransferDate;
			var onInstall = lastTransferRecord.OnLifelength;
			var onInstallDate = installationDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var onInstallHours = onInstall.Hours != null ? onInstall.Hours.ToString() : "";
			var onInstallCycles = onInstall.Cycles != null ? onInstall.Cycles.ToString() : "";
			var onInstallDays = onInstall.Days != null ? onInstall.Days.ToString() : "";
			var sinceInstall = new Lifelength(reportAircraftLifeLenght);
            sinceInstall.Substract(onInstall);
			var sinceInstallHours = sinceInstall.Hours != null ? sinceInstall.Hours.ToString() : "";
			var sinceInstallCycles = sinceInstall.Cycles != null ? sinceInstall.Cycles.ToString() : "";
			var sinceInstallDays = sinceInstall.Days != null ? sinceInstall.Days.ToString() : "";
			var warranty = _reportedBaseComponent.Warranty;
			var warrantyRemain = new Lifelength(warranty);
            warrantyRemain.Substract(reportAircraftLifeLenght);
            warrantyRemain.Resemble(warranty);
			var warrantyHours = warranty.Hours != null ? warranty.Hours.ToString() : "";
			var warrantyCycles = warranty.Cycles != null ? warranty.Cycles.ToString() : "";
			var warrantyDays = warranty.Days != null ? warranty.Days.ToString() : "";
			var warrantyRemainHours = warrantyRemain.Hours != null ? warrantyRemain.Hours.ToString() : "";
			var warrantyRemainCycles = warrantyRemain.Cycles != null ? warrantyRemain.Cycles.ToString() : "";
			var warrantyRemainDays = warrantyRemain.Days != null ? warrantyRemain.Days.ToString() : "";
			var aircraftOnInstall = Lifelength.Null;
	        if (parentAircaft != null)
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
				aircraftOnInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, installationDate);
				GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircaft);
            }
			var aircraftOnInstallHours = aircraftOnInstall.Hours != null ? aircraftOnInstall.Hours.ToString() : "";
			var aircraftOnInstallCycles = aircraftOnInstall.Cycles != null ? aircraftOnInstall.Cycles.ToString() : "";
			var aircraftOnInstallDays = aircraftOnInstall.Days != null ? aircraftOnInstall.Days.ToString() : "";


	        var sinceOverhaul = Lifelength.Null;
			var lastOverhaulDate = DateTime.MinValue;
			var lastOverhaulDateString = "";

			#region поиск последнего ремонта и расчет времени, прошедшего с него
			//поиск директив деталей
			var directives = GlobalObjects.ComponentCore.GetComponentDirectives(_reportedBaseComponent, true);
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

            destinationDataSet.BaseDetailTable.AddBaseDetailTableRow(_reportedBaseComponent.ATAChapter.ToString(),
                                                                     _reportedBaseComponent.AvionicsInventory.ToString(),
                                                                     _reportedBaseComponent.PartNumber,
                                                                     _reportedBaseComponent.SerialNumber,
                                                                     _reportedBaseComponent.Model != null ? _reportedBaseComponent.Model.ToString() : "",
                                                                     _reportedBaseComponent.BaseComponentType.ToString(),
                                                                     location,
																	 lastTransferRecord.Position,
                                                                     _reportedBaseComponent.Manufacturer,
                                                                     manufactureDate,
                                                                     deliveryDate,
                                                                     _reportedBaseComponent.MPDItem,
                                                                     _reportedBaseComponent.Suppliers != null
                                                                        ? _reportedBaseComponent.Suppliers.ToString()
                                                                        : "",
                                                                     status,
                                                                     _reportedBaseComponent.Cost,
                                                                     _reportedBaseComponent.CostOverhaul,
                                                                     _reportedBaseComponent.CostServiceable,
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
	            AverageUtilization au;
	            if (parentAircaft != null)
	            {
					var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
					au = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
				}
	            else
		            au = _reportedBaseComponent.AverageUtilization;

                averageUtilizationHours = (int)au.Hours;
                averageUtilizationCycles = (int)au.Cycles;
                averageUtilizationType = au.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
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
                                                                         reportAircraftLifeLenght.ToHoursMinutesFormat(""),
                                                                         reportAircraftLifeLenght.Cycles != null && reportAircraftLifeLenght.Cycles != 0
                                                                            ? reportAircraftLifeLenght.Cycles.ToString()
                                                                            : "",
                                                                         "", "", "", "",
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        
        }

        #endregion

        #region private void AddDirectiveToDataset(Directive directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedDirective">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(Directive reportedDirective, DirectivesListDataSet destinationDataSet)
        {

            string title;
            string eo;
            string sb;

            if(_directiveType == DirectiveType.EngineeringOrders)
            {
                title = reportedDirective.EngineeringOrders;
                sb = reportedDirective.Title;
                eo = reportedDirective.ServiceBulletinNo;
            }
            else if (_directiveType == DirectiveType.SB)
            {
                title = reportedDirective.ServiceBulletinNo;
                sb = reportedDirective.Title;
                eo = reportedDirective.EngineeringOrders;
            }
            else
            {
                title = reportedDirective.Title;
                eo = reportedDirective.EngineeringOrders;
                sb = reportedDirective.ServiceBulletinNo;
            }

            string remarks = reportedDirective.LastPerformance != null 
                ? reportedDirective.LastPerformance.Remarks 
                : reportedDirective.Remarks;

            
            var status = "";
            if (reportedDirective.Status == DirectiveStatus.Closed ||
                reportedDirective.Status == DirectiveStatus.Open ||
                reportedDirective.Status == DirectiveStatus.Repetative||
                reportedDirective.Status == DirectiveStatus.NotApplicable) 
                status = reportedDirective.Status.ShortName;
            var effectivityDate = UsefulMethods.NormalizeDate(reportedDirective.Threshold.EffectiveDate);
            var equipment = reportedDirective.NDTType.ShortName;
            var kits = "";
            var num = 1;
            foreach (AccessoryRequired kit in reportedDirective.Kits)
            {
                kits += num + ": " + kit.PartNumber + "\n";
                num++;
            }

            //расчет остатка с даты производства и с эффективной даты
            Lifelength sinceNewThreshold = Lifelength.Null, sinceEffDateThreshold = Lifelength.Null;
            var sinceEffDateCompliance = Lifelength.Null;
            Lifelength sinceNewRemain = Lifelength.Null, sinceEffDateRemain = Lifelength.Null;

            Lifelength firstCompliance = Lifelength.Null,
                       lastCompliance = Lifelength.Null,
                       repeatInterval = Lifelength.Null, remain = Lifelength.Null;
            string firstComplianceDate = "", 
                   lastComplianceDate = "", sinceNewComplianceDate = "";
            var used = Lifelength.Null;

			//TODO:(Evgenii Babak) расчетом ресурсов должен заниматься калькулятор
			//расчет остатка от выполнения с даты производтсва
			if (reportedDirective.Threshold.FirstPerformanceSinceNew != null)
            {
                sinceNewThreshold = reportedDirective.Threshold.FirstPerformanceSinceNew;
                if(sinceNewThreshold.Days != null)
                {
                    sinceNewComplianceDate =
                        _manufactureDate.AddDays(sinceNewThreshold.Days.Value).ToString(
                            new GlobalTermsProvider()["DateFormat"].ToString());
                }
                if (reportedDirective.LastPerformance == null)
                {
                    sinceNewRemain.Add(reportedDirective.Threshold.FirstPerformanceSinceNew);
                    sinceNewRemain.Substract(_current);
                    sinceNewRemain.Resemble(reportedDirective.Threshold.FirstPerformanceSinceNew);
                }
            }
            if (reportedDirective.Threshold.FirstPerformanceSinceEffectiveDate != null)
            {
                sinceEffDateThreshold = reportedDirective.Threshold.FirstPerformanceSinceEffectiveDate;
                if (reportedDirective.Threshold.EffectiveDate < DateTime.Today)
                {
                    sinceEffDateCompliance =
                        GlobalObjects.CasEnvironment.Calculator.
                            GetFlightLifelengthOnEndOfDay(_reportedBaseComponent, reportedDirective.Threshold.EffectiveDate);
                }

                sinceEffDateCompliance.Add(reportedDirective.Threshold.FirstPerformanceSinceEffectiveDate);
                sinceEffDateCompliance.Resemble(reportedDirective.Threshold.FirstPerformanceSinceEffectiveDate);

                if (reportedDirective.LastPerformance == null)
                {
                    sinceEffDateRemain.Add(sinceEffDateCompliance);
                    sinceEffDateRemain.Substract(_current);
                    sinceEffDateRemain.Resemble(sinceEffDateCompliance);
                }
            }

            GlobalObjects.PerformanceCalculator.GetNextPerformance(reportedDirective);
            if (reportedDirective.LastPerformance != null)
            {
                firstComplianceDate =
                    reportedDirective.PerformanceRecords[0].RecordDate.ToString(
                        new GlobalTermsProvider()["DateFormat"].ToString());
                firstCompliance = reportedDirective.PerformanceRecords[0].OnLifelength;

                if (reportedDirective.Threshold.RepeatInterval != null) 
                    repeatInterval = reportedDirective.Threshold.RepeatInterval;

                lastComplianceDate =
                    reportedDirective.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                lastCompliance = reportedDirective.LastPerformance.OnLifelength;

                used.Add(_current);
                used.Substract(reportedDirective.LastPerformance.OnLifelength);

                if (reportedDirective.NextPerformanceSource != null)
                {
                    remain.Add(reportedDirective.NextPerformanceSource);
                    remain.Substract(_current);
                    remain.Resemble(reportedDirective.Threshold.RepeatInterval);
                }
            }

            var nextComplianceDate = reportedDirective.NextPerformanceDate != null
                                            ? ((DateTime)reportedDirective.NextPerformanceDate).ToString(
                                                new GlobalTermsProvider()["DateFormat"].ToString())
                                            : "";
            var nextCompliance = reportedDirective.NextPerformanceSource;

            var condition = reportedDirective.Condition.ToString();
            var ata = reportedDirective.ATAChapter;

            destinationDataSet.ItemsTable.AddItemsTableRow(reportedDirective.Applicability,
                                                           remarks,
                                                           reportedDirective.HiddenRemarks,
                                                           reportedDirective.Description,
                                                           title,
                                                           reportedDirective.Paragraph,
                                                           reportedDirective.WorkType.ToString(),
                                                           status,
                                                           effectivityDate,
                                                           sinceNewThreshold.Hours ?? 0,
                                                           sinceNewThreshold.Cycles ?? 0,
                                                           sinceNewComplianceDate,
                                                           reportedDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L",
                                                           sinceNewRemain.Hours ?? 0,
                                                           sinceNewRemain.Cycles ?? 0,
                                                           sinceNewRemain.Days ?? 0,
                                                           sinceEffDateThreshold.Hours ?? 0,
                                                           sinceEffDateThreshold.Cycles ?? 0,
                                                           sinceEffDateThreshold.Days != null ? sinceEffDateThreshold.Days.ToString() : "",
                                                           reportedDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst ? "W.O.F" : "W.O.L",
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
                                                           used.Days ?? 0,
                                                           used.Hours ?? 0,
                                                           used.Cycles ?? 0,
                                                           nextComplianceDate,
                                                           nextCompliance.Hours ?? 0,
                                                           nextCompliance.Cycles ?? 0,
                                                           nextCompliance.ToStrings(),
                                                           remain.Days != null ? remain.Days.ToString() : "",
                                                           remain.Hours ?? 0,
                                                           remain.Cycles ?? 0,
                                                           remain.ToStrings(),
                                                           condition,
                                                           reportedDirective.ManHours,
                                                           reportedDirective.Cost,
                                                           kits,
                                                           equipment,
                                                           ata.ShortName,
                                                           ata.FullName,
                                                           reportedDirective.ADType == ADType.Airframe ? "AF" : "AP",
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
            string firsttitle = "";
            string discriptiontitle = "";
            string secondtitle = "";

            if (_directiveType == DirectiveType.AirworthenessDirectives)
            {
                firsttitle = "FAA AD";
                discriptiontitle = "DESCRIPTION";
                secondtitle = "SERVICE BULLETIN\n (EO, MJC)";
            }
            if (_directiveType == DirectiveType.EngineeringOrders)
            {
                firsttitle = "EO";
                secondtitle = "FAA AD\n (SB)";
                discriptiontitle = "DESCRIPTION";
            }
            if (_directiveType == DirectiveType.SB)
            {
                firsttitle = "SERVICE BULLETIN";
                secondtitle = "FAA AD\n (EO, MJC)";
                discriptiontitle = "DESCRIPTION";
            }
            if (_directiveType == DirectiveType.OutOfPhase)
            {
                firsttitle = "\n ITEM #";
                secondtitle = "\n (EO, MJC)";
                discriptiontitle = "REQUIREMENT";
            }
            if (_directiveType == DirectiveType.DamagesRequiring)
            {
                firsttitle = "\n ITEM #";
                secondtitle = "\n (EO, MJC)";
                discriptiontitle = "DESCRIPTION";
            }

            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, OperatorLogotype, _filterSelection, _dateAsOf, firsttitle, discriptiontitle, secondtitle, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region private void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)

        private void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)
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
