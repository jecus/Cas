using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    public class LandingGearLLPStatusBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private List<Component> _reportedItems = new List<Component>();
        private Forecast _forecast;

        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "COMPONENT STATUS";
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
            get
            {
                return _reportedAircraft;
            }
            set
            {
                _reportedAircraft = value;
                if(value == null)return;
				_reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
				_manufactureDate = value.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                OperatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
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
                _reportedAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
				_manufactureDate = _reportedBaseComponent.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge;
                _reportedItems.Clear();
            }
        }
        #endregion

        #region public List<Detail> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<Component> ReportedDirectives
        {
            get
            {
                return _reportedItems;
            }
            set
            {
                _reportedItems = value;
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

        #region public string FilterSelection

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

        #region Methods

        #region public void AddDirectives(object[] directives)

        public void AddDirectives(object [] directives)
        {
            _reportedItems.Clear();
            foreach (object t in directives)
            {
                if (t is Component) _reportedItems.Add((Component)t);
            }
        }

        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            LandingGearLLPReport report = new LandingGearLLPReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual LandingGearStatusDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual LandingGearStatusDataSet GenerateDataSet()
        {
            LandingGearStatusDataSet dataset = new LandingGearStatusDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(LandingGearStatusDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(LandingGearStatusDataSet dataset)
        {
            /* List<String> colors = new List<string>();
            for (int i = 0; i < HighlightCollection.Instance.Count; i++ )
            {
                colors.Add(HighlightCollection.Instance[i].Color.R.ToString()+" "+
                            HighlightCollection.Instance[i].Color.G.ToString()+" "+
                            HighlightCollection.Instance[i].Color.B.ToString());
            }
            MessageBox.Show(string.Join("\r\n",colors.ToArray()));*/
            foreach (Component t in _reportedItems)
            {
                AddDirectiveToDataset(t, dataset);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(LandingGearStatusDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(LandingGearStatusDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ShortName;
            var registrationNumber = _reportedAircraft.RegistrationNumber;
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

        #region private void AddBaseDetailToDataset(LandingGearStatusDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(LandingGearStatusDataSet destinationDataSet)
        {
            if (_reportedBaseComponent == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);

            var manufactureDate = _reportedBaseComponent.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var deliveryDate = _reportedBaseComponent.DeliveryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var status = _reportedBaseComponent.Serviceable ? "Serviceable" : "Unserviceable";
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
            var parentAircaft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
			var aircraftOnInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, installationDate);
			var aircraftOnInstallHours = aircraftOnInstall.Hours != null ? aircraftOnInstall.Hours.ToString() : "";
            var aircraftOnInstallCycles = aircraftOnInstall.Cycles != null ? aircraftOnInstall.Cycles.ToString() : "";
            var aircraftOnInstallDays = aircraftOnInstall.Days != null ? aircraftOnInstall.Days.ToString() : "";

            var sinceOverhaul = Lifelength.Null;
            var lastOverhaulDate = DateTime.MinValue;
            var lastOverhaulDateString = "";

			#region поиск последнего ремонта и расчет времени, прошедшего с него
			//поиск директив деталей
			var directives = GlobalObjects.ComponentCore.GetComponentDirectives( _reportedBaseComponent, true);
            //поиск директивы ремонта
            var overhauls = directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
            //поиск последнего ремонта
            ComponentDirective lastOverhaul = null;
            foreach (ComponentDirective d in overhauls)
            {
                if (d.LastPerformance == null || d.LastPerformance.RecordDate <= lastOverhaulDate) continue;

                lastOverhaulDate = d.LastPerformance.RecordDate;
                lastOverhaul = d;
            }

            if (lastOverhaul != null)
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
																	 _reportedBaseComponent.GetParentAircraftRegNumber(),
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
                                                                     reportAircraftLifeLenght.ToHoursMinutesFormat(""),
                                                                     sinceNewCycles,
                                                                     sinceNewDays,
                                                                     reportAircraftLifeLenght.ToStrings(),
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
                                                                     sinceOverhaul.Cycles ?? 0, 
                                                                     sinceOverhaul.ToStrings());
        }

        #endregion

        #region public void AddDirectiveToDataset(Detail DetailDirective, LandingGearStatusDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedComponentобавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(Component reportedComponent, LandingGearStatusDataSet destinationDataSet)
        {                                    
            Lifelength total = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(reportedComponent);

            string domTtsnTcsn = SmartCore.Auxiliary.Convert.GetDateFormat(reportedComponent.ManufactureDate, "/");
            if(domTtsnTcsn != "")
                domTtsnTcsn += "\n";
            domTtsnTcsn += total.ToHoursMinutesAndCyclesStrings("FH", "FC");

            string position = reportedComponent.Position;
            string pos = "";
            string dwgItem = "";
            string pattern = @"\d+";

            Regex r = new Regex(pattern);
            Match m = r.Match(position);
            if (m.Success)
            {
                pos = position.Substring(0, m.Index);
                dwgItem = position.Substring(m.Index);
            }

            ComponentRecordType workType = ComponentRecordType.Unknown;

            ComponentDirective overhaul =
                reportedComponent.ComponentDirectives.FirstOrDefault(dd => dd.DirectiveType == ComponentRecordType.Overhaul);
            Lifelength interval = Lifelength.Null;
            Lifelength used = Lifelength.Null;
            Lifelength remain = Lifelength.Null;

            string lastPerformanceDateString = "";
            string lastPerformanceHours = "";
            string lastPerformanceCycles = "";
            if(overhaul != null)
            {
                if(overhaul.LastPerformance != null)
                {
                    DirectiveRecord lastPerformance = overhaul.LastPerformance;
                    interval = overhaul.Threshold.RepeatInterval;
                    lastPerformanceDateString =
                        SmartCore.Auxiliary.Convert.GetDateFormat(lastPerformance.RecordDate, "/");
                    lastPerformanceHours = lastPerformance.OnLifelength.ToHoursMinutesFormat("FH");
                    lastPerformanceCycles = lastPerformance.OnLifelength.Cycles != null &&
                                            lastPerformance.OnLifelength.Cycles != 0
                                                ? lastPerformance.OnLifelength.Cycles.ToString()
                                                : "";
                    used = total - lastPerformance.OnLifelength;
                    used.Resemble(interval);
                }
                else
                {
                    interval = overhaul.Threshold.FirstPerformanceSinceNew;
                    used = new Lifelength(total);
                    used.Resemble(interval);
                }
                workType = overhaul.DirectiveType;
                remain = new Lifelength(overhaul.Remains);
            }

            destinationDataSet.ItemsTable.AddItemsTableRow(
                dwgItem,
                reportedComponent.ATAChapter.ToString(),
                reportedComponent.PartNumber,
                reportedComponent.SerialNumber,
                pos,
                reportedComponent.Description,
                reportedComponent.MaintenanceControlProcess.ToString(),
                SmartCore.Auxiliary.Convert.GetDateFormat(reportedComponent.TransferRecords.GetLast().TransferDate, "/"),
                reportedComponent.LifeLimit.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                total.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                reportedComponent.Remains.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                workType.ToString(),
                interval.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                lastPerformanceDateString,
                lastPerformanceHours,
                lastPerformanceCycles,
                used.Days != null ? used.Days.ToString() : "",
                used.Hours != null ? used.Hours.ToString() : "",
                used.Cycles != null ? used.Cycles.ToString(): "",
                used.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                "", "", "",
                remain.ToHoursMinutesAndCyclesStrings("FH", "FC"),
                reportedComponent.Condition.ToString(),
                reportedComponent.ManHours,
                reportedComponent.Cost,
                reportedComponent.Kits.ToString(),
                "",
                reportedComponent.Remarks,
                reportedComponent.Status.ToString(),
                domTtsnTcsn);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(LandingGearStatusDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(LandingGearStatusDataSet destinationDateSet)
        {
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            var averageUtilizationHours = 0;
            int averageUtilizationCycles = 0;
            string averageUtilizationType = "";
	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
            if(_reportedBaseComponent != null)
            {
                if (_forecast == null)
                {
					var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
					var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

					//TODO:(Evgenii Babak) убрать повторяющийся код при использовании AverageUtilization
					averageUtilizationHours = (int)averageUtilization.Hours;
					averageUtilizationCycles = (int)averageUtilization.Cycles;
					averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
				}
                else
                {
					//TODO:(Evgenii Babak) убрать повторяющийся код при использовании AverageUtilization
					averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
                    averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
                    averageUtilizationType =
                        _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

                }    
            }
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, 
                                                                                OperatorLogotype, 
                                                                                _filterSelection, 
                                                                                DateAsOf, 
                                                                                reportFooter, 
                                                                                reportFooterPrepared, 
                                                                                reportFooterLink,
                                                                                averageUtilizationCycles,
                                                                                averageUtilizationHours,
                                                                                averageUtilizationType);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(LandingGearStatusDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(LandingGearStatusDataSet destinationDataSet)
        {
            double avgUtilizationCycles = _forecast != null ? _forecast.ForecastDatas[0].AverageUtilization.Cycles : 0;
            double avgUtilizationHours = _forecast != null ? _forecast.ForecastDatas[0].AverageUtilization.Hours : 0;
            string avgUtilizationType = _forecast != null
                                            ? _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval.ToString()
                                            : "";
            int forecastCycles = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Cycles != null 
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Cycles 
                    : 0
                : 0;
            int forecastHours = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Hours != null 
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Hours 
                    : 0
                : 0;
            int forecastDays = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Days != null 
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Days 
                    : 0
                : 0;
            string forecastDate = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
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
