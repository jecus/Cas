using System;
using System.Collections.Generic;
using System.Data;
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
using SmartCore.Filters;
using TempUIExtentions;

namespace CASReports.Builders
{
    public class DirectivesReportBuilderLitAVIAEng : AbstractReportBuilder
    {
        #region Fields

        protected string _reportTitle = "AD STATUS";
        protected string _filterSelection;
        protected byte[] _operatorLogotype;
        protected Aircraft _reportedAircraft;
        protected BaseComponent _reportedBaseComponent;
        protected List<Directive> _reportedDirectives = new List<Directive>();

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Forecast _forecast;
        private DirectiveType _directiveType = DirectiveType.AirworthenessDirectives;
        private string _dateAsOf = "";
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
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
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
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge;
                _reportedDirectives.Clear();
            }
        }

        public DirectiveType DirectiveType
        {
            protected get { return _directiveType; }
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

        #region public Forecast Forecast

        public Forecast Forecast
        {
            set { _forecast = value; }
        }
        #endregion

        #region public CommonFilterCollection ReportTitle

        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public CommonFilterCollection FilterSelection
        {
            set { GetFilterSelection(value); }
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

        #region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        {
            if (_reportedAircraft != null)
            {
                _filterSelection = "All";
                if (filterCollection == null || filterCollection.IsEmpty)
                    return;
                _filterSelection = filterCollection.ToString();
            }
            else
            {
                if (_reportedBaseComponent != null)
                {
                    _filterSelection = "All";
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
                        _filterSelection = _reportedBaseComponent.TransferRecords.GetLast().Position;
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Engine)
                        _filterSelection = BaseComponentType.Engine + " " + _reportedBaseComponent.TransferRecords.GetLast().Position;
                    if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Apu)
                        _filterSelection = BaseComponentType.Apu.ToString();
                    if (filterCollection == null || filterCollection.IsEmpty)
                        return;
                    _filterSelection += (" " + filterCollection);
                }
                else
                {
                    _filterSelection = "All";
                }
            }
        
        }
        #endregion

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
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            var report = new DirectivesListReportScatEng();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected virtual DataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        protected virtual DataSet GenerateDataSet()
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

        #region protected virtual void AddDirectivesToDataSet(DirectivesListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(DirectivesListDataSet dataset)
        {
            foreach (var directive in _reportedDirectives)
            {
                AddDirectiveToDataset(directive, dataset);
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

            Lifelength reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            string manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string serialNumber = _reportedAircraft.SerialNumber;
            string model = _reportedAircraft.Model.ShortName;
            int sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            int sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            string registrationNumber = _reportedAircraft.RegistrationNumber;
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;

			if (_forecast == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = (int)averageUtilization.Hours;
                averageUtilizationCycles = (int)averageUtilization.Cycles;
                averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
            }
            else
            {
                averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
                averageUtilizationType =
                   _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }

            string lineNumber = _reportedAircraft.LineNumber;
            string variableNumber = _reportedAircraft.VariableNumber;
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

        #region private void AddBaseDetailToDataset(DirectivesListDataSet destinationDataSet)

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
			var remain = new Lifelength(lifeLimit);
            remain.Substract(reportAircraftLifeLenght);
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
			var aircraftCurrent = Lifelength.Null;
            if( parentAircaft != null)
            {
	            var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
				aircraftOnInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, installationDate);
				aircraftCurrent = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircaft);   
            }
			var aircraftOnInstallHours = aircraftOnInstall.Hours != null ? aircraftOnInstall.Hours.ToString() : "";
			var aircraftOnInstallCycles = aircraftOnInstall.Cycles != null ? aircraftOnInstall.Cycles.ToString() : "";
			var aircraftOnInstallDays = aircraftOnInstall.Days != null ? aircraftOnInstall.Days.ToString() : "";
			var aircraftCurrentHours = aircraftCurrent.Hours ?? 0;
			var aircraftCurrentCycles = aircraftCurrent.Cycles ?? 0;


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
            if (_forecast == null)
            {
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
				var au = parentAircaft != null
                                            ? averageUtilization
											: _reportedBaseComponent.AverageUtilization;
                averageUtilizationHours = (int)au.Hours;
                averageUtilizationCycles = (int)au.Cycles;
                averageUtilizationType = au.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
            }
            else
            {
                averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
                averageUtilizationType =
                    _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

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

        #region public void AddDirectiveToDataset(object directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedDirective">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(Directive reportedDirective, DirectivesListDataSet destinationDataSet)
        {
            string references = reportedDirective.Paragraph;
            string title;
            string eo;
            string sb;

            string s1 = reportedDirective.Title;
            if (!string.IsNullOrEmpty(reportedDirective.Paragraph.Trim()))
                s1 += "\n§ " + reportedDirective.Paragraph;

            if(_directiveType == DirectiveType.EngineeringOrders)
            {
                title = reportedDirective.EngineeringOrders;
                sb = s1;
                eo = reportedDirective.ServiceBulletinNo;
            }
            else if (_directiveType == DirectiveType.SB)
            {
                title = reportedDirective.ServiceBulletinNo;
                sb = s1;
                eo = reportedDirective.EngineeringOrders;
            }
            else
            {
                title = s1;
                eo = reportedDirective.EngineeringOrders;
                sb = reportedDirective.ServiceBulletinNo;
            }
            Lifelength sinceNewThreshold = Lifelength.Null, sinceEffDateThreshold = Lifelength.Null;
            Lifelength sinceEffDateCompliance = Lifelength.Null;
            Lifelength sinceNewRemain = Lifelength.Null, sinceEffDateRemain = Lifelength.Null;
            Lifelength firstCompliance = Lifelength.Null,
                       lastCompliance = Lifelength.Null,
                       repeatInterval = Lifelength.Null, remain = Lifelength.Null;
            string firstComplianceDate = "",
                   lastComplianceDate = "", sinceNewComplianceDate = "";
            Lifelength used = Lifelength.Null;

            string remarks = reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.Remarks : reportedDirective.Remarks;
            string performanceType = reportedDirective.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
                                         ? "W.O.F"
                                         : "W.O.L";
            string effectivityDate = SmartCore.Auxiliary.Convert.GetDateFormat(reportedDirective.Threshold.EffectiveDate, "/");
            string equipment = reportedDirective.NDTType.ShortName;
            string kits = "";
            int num = 1;
            foreach (AccessoryRequired kit in reportedDirective.Kits)
            {
                kits += num + ": " + kit.PartNumber + "\n";
                num++;
            }
			//TODO:(Evgenii Babak) расчетом ресурсов должен заниматься калькулятор
            //расчет остатка с даты производства и с эффективной даты
            //расчет остатка от выполнения с даты производтсва
            if (reportedDirective.Threshold.FirstPerformanceSinceNew != null)
            {
                sinceNewThreshold = reportedDirective.Threshold.FirstPerformanceSinceNew;
                if (sinceNewThreshold.Days != null)
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


				sinceEffDateRemain.Add(reportedDirective.Remains);
            }

            GlobalObjects.PerformanceCalculator.GetNextPerformance(reportedDirective);
            if (reportedDirective.LastPerformance != null)
            {
                firstComplianceDate =
                    reportedDirective.PerformanceRecords[0].RecordDate.ToString(
                        new GlobalTermsProvider()["DateFormat"].ToString());
                firstCompliance = reportedDirective.PerformanceRecords[0].OnLifelength;

                if (reportedDirective.Threshold.RepeatInterval != null) repeatInterval = reportedDirective.Threshold.RepeatInterval;

                lastComplianceDate =
                    reportedDirective.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                lastCompliance = reportedDirective.LastPerformance.OnLifelength;

                used.Add(_current);
                used.Substract(reportedDirective.LastPerformance.OnLifelength);

                if (reportedDirective.NextPerformanceSource != null && !reportedDirective.NextPerformanceSource.IsNullOrZero())
                {
                    remain.Add(reportedDirective.NextPerformanceSource);
                    remain.Substract(_current);
                    remain.Resemble(reportedDirective.Threshold.RepeatInterval);
                }
            }

	        var canadianTitle = "";
	        if (reportedDirective.Title.Contains('/'))
	        {
		        var res = reportedDirective.Title.Split('/');
		        canadianTitle = res[0];
		        title = res[1];
	        }
	        else if(reportedDirective.Title.StartsWith("C"))
	        {
		        canadianTitle = reportedDirective.Title;
		        title = "";
			}
	        else
	        {
				canadianTitle = "";
		        title = reportedDirective.Title;
			}



            string nextComplianceDate = 
                reportedDirective.NextPerformanceDate != null
                    ? ((DateTime)reportedDirective.NextPerformanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                    : "";
            Lifelength nextCompliance = reportedDirective.NextPerformanceSource;
            NextPerformance np = reportedDirective.NextPerformance;
            destinationDataSet.ItemsTable.AddItemsTableRow(reportedDirective.Applicability,
                                                           reportedDirective.Remarks,
                                                           reportedDirective.HiddenRemarks,
                                                           reportedDirective.Description,
                                                           title,
                                                           references,
                                                           reportedDirective.WorkType.ToString(),
                                                           reportedDirective.Status.FullName,
                                                           effectivityDate,
                                                           sinceNewThreshold.Hours ?? 0,
                                                           sinceNewThreshold.Cycles ?? 0,
                                                           sinceNewComplianceDate,
                                                           performanceType,
                                                           sinceNewRemain.Hours ?? 0,
                                                           sinceNewRemain.Cycles ?? 0,
                                                           sinceNewRemain.Days ?? 0,
                                                           sinceEffDateThreshold.Hours ?? 0,
                                                           sinceEffDateThreshold.Cycles ?? 0,
                                                           sinceEffDateThreshold.Days != null ? sinceEffDateThreshold.Days.ToString() : "",
                                                           performanceType,
                                                           sinceEffDateRemain.Hours ?? 0,
                                                           sinceEffDateRemain.Cycles ?? 0,
                                                           sinceEffDateRemain.Days ?? 0,
                                                           firstComplianceDate,
                                                           firstCompliance.Hours ?? 0,
                                                           firstCompliance.Cycles ?? 0,
                                                           reportedDirective.Threshold.FirstPerformanceToStrings(),
                                                           repeatInterval.Days ?? 0,
                                                           repeatInterval.Hours ?? 0,
                                                           repeatInterval.Cycles ?? 0, 
                                                           repeatInterval.ToStrings(),
                                                           lastComplianceDate,
                                                           lastCompliance.Hours ?? 0,
                                                           lastCompliance.Cycles ?? 0,
                                                           reportedDirective.LastPerformance != null 
                                                                ? reportedDirective.LastPerformance.ToStrings("/")
                                                                : "",
                                                           used.Days ?? 0,
                                                           used.Hours ?? 0,
                                                           used.Cycles ?? 0,
                                                           nextComplianceDate,
                                                           nextCompliance.Hours ?? 0,
                                                           nextCompliance.Cycles ?? 0,
                                                           np != null ? np.ToStrings("/") : "",
                                                           remain.Days != null ? remain.Days.ToString() : "",
                                                           remain.Hours ?? 0,
                                                           remain.Cycles ?? 0,
                                                           reportedDirective.Remains.ToStrings(),
                                                           reportedDirective.Condition.ToString(),
                                                           reportedDirective.Cost,
                                                           reportedDirective.ManHours,
                                                           kits,
                                                           equipment,
                                                           reportedDirective.ATAChapter != null ? reportedDirective.ATAChapter.ShortName : "",
                                                           reportedDirective.ATAChapter != null ? reportedDirective.ATAChapter.FullName : "",
                                                           reportedDirective.ADType == ADType.Airframe ? "AF" : "AP",
                                                           sb,
                                                           eo != "" ?'(' + eo + ')' : "",
														   canadianTitle, reportedDirective.StcNo);
        }

        #endregion

        #region protected virtual void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected virtual void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)
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
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, firsttitle,secondtitle, discriptiontitle, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(DirectivesListDataSet destinationDataSet)
        {
            ForecastData fd = _forecast != null ? _forecast.GetForecastDataFrame() : null;
            if (fd == null)
            {
                destinationDataSet.ForecastTable.AddForecastTableRow(0,
                                                                     0,
                                                                     "",
                                                                     0,
                                                                     0,
                                                                     0,
                                                                     "");
                return;
            }
            double avgUtilizationCycles = fd.AverageUtilization.Cycles;
            double avgUtilizationHours = fd.AverageUtilization.Hours;
            string avgUtilizationType = fd.AverageUtilization.SelectedInterval.ToString();
            int forecastCycles = fd.ForecastLifelength.Cycles != null
                                     ? (int)fd.ForecastLifelength.Cycles
                                     : 0;
            int forecastHours = fd.ForecastLifelength.Hours != null
                                    ? (int)fd.ForecastLifelength.Hours
                                    : 0;
            int forecastDays = fd.ForecastLifelength.Days != null
                                   ? (int)fd.ForecastLifelength.Days
                                   : 0;
            string forecastDate = "";

            if (fd.SelectedForecastType == ForecastType.ForecastByDate)
            {
                forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(fd.ForecastDate);
            }
            else if (fd.SelectedForecastType == ForecastType.ForecastByPeriod)
            {
                forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(fd.LowerLimit) + " - " +
                               SmartCore.Auxiliary.Convert.GetDateFormat(fd.ForecastDate);
            }
            else if (fd.SelectedForecastType == ForecastType.ForecastByCheck)
            {
                if (fd.NextPerformanceByDate)
                {
                    forecastDate = fd.NextPerformanceString;
                }
                else
                {
                    forecastDate = string.Format("{0}. {1}",
                        fd.CheckName,
                        SmartCore.Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(fd.NextPerformance.PerformanceDate)));
                }
            }

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
