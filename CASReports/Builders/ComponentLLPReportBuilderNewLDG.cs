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
    public class ComponentLLPReportBuilderNewLDG : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private List<ComponentDirective> _reportedItems = new List<ComponentDirective>();
        private Forecast _forecast;

        private string _dateAsOf = "";

        public string _reportTitle = "";
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
        public List<ComponentDirective> ReportedDirectives
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
                if (t is ComponentDirective) _reportedItems.Add((ComponentDirective)t);
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
	        var report = new ComponentListLLPReportLDG();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual ComponentListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual LLPDiskSheetDataSet GenerateDataSet()
        {
            var dataset = new LLPDiskSheetDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(LLPDiskSheetDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(LLPDiskSheetDataSet dataset)
        {
            foreach (var t in _reportedItems)
                AddDirectiveToDataset(t, dataset);
        }

        #endregion

        #region private void AddAircraftToDataset(LLPDiskSheetDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(LLPDiskSheetDataSet destinationDataSet)
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

        #region private void AddBaseDetailToDataset(LLPDiskSheetDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(LLPDiskSheetDataSet destinationDataSet)
        {
            if (_reportedBaseComponent == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);

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
            var installationDate = _reportedBaseComponent.TransferRecords.GetLast().TransferDate;
			//TODO:(Evgenii Babak)  нужно брать наработку с записи о перемещении, а не пересчитывать заново
			var onInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_reportedBaseComponent, installationDate);
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
            var aircraftCurrent = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircaft);

            var sinceOverhaul = Lifelength.Null;
            var lastOverhaulDate = DateTime.MinValue;
            var lastOverhaulDateString = "";

            #region поиск последнего ремонта и расчет времени, прошедшего с него
            //поиск директив деталей
            List<ComponentDirective> directives = GlobalObjects.ComponentCore.GetComponentDirectives( _reportedBaseComponent, true);
            //поиск директивы ремонта
            List<ComponentDirective> overhauls = directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
            //поиск последнего ремонта
            ComponentDirective lastOverhaul = null;
            foreach (ComponentDirective d in directives)
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
                                                                     _reportedBaseComponent.Model != null ? _reportedBaseComponent.Model.FullName : "",
                                                                     _reportedBaseComponent.BaseComponentType.ToString(),
																	 _reportedBaseComponent.GetParentAircraftRegNumber(),
																	 _reportedBaseComponent.TransferRecords.GetLast().Position,
                                                                     _reportedBaseComponent.Thrust,
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

		#region public void AddDirectiveToDataset(Detail reportedComponent, LLPDiskSheetDataSet destinationDataSet)

		/// <summary>
		/// Добавляется элемент в таблицу данных
		/// </summary>
		/// <param name="reportedComponent">Добавлямая директива</param>
		/// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
		private void AddDirectiveToDataset(ComponentDirective reportedComponent, LLPDiskSheetDataSet destinationDataSet)
        {
                destinationDataSet.ItemsTable.AddItemsTableRow(reportedComponent.PartNumber,
                                                               reportedComponent.SerialNumber,
                                                               reportedComponent.Description,
                                                               GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject)reportedComponent.ParentComponent).Cycles?.ToString(),
																0,
                                                               0,
                                                               0,
                                                               0,
                                                               0,
                                                               0,
                                                               0,
                                                               0,
                                                               0,
                                                               reportedComponent.NextPerformance?.Remains?.Cycles ?? 0,
                                                               0,
                                                               0,
                                                               0,
                                                               reportedComponent.Condition.ToString(),
                                                               reportedComponent.ParentComponent.Position,
                                                               reportedComponent.Remarks,
                                                               reportedComponent.DirectiveType.FullName,
                                                               reportedComponent.FirstPerformanceSinceNew?.Cycles.ToString(),
                                                               reportedComponent.NextPerformance?.Remains?.Cycles?.ToString());
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(LLPDiskSheetDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(LLPDiskSheetDataSet destinationDateSet)
        {
	        var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
            string[] categoryNames = { "N/A", "N/A", "N/A", "N/A" };
            var categories = GlobalObjects.CasEnvironment.GetDictionary<LLPLifeLimitCategory>()
                .OfType<LLPLifeLimitCategory>()
                .Where(c => c.AircraftModel!= null && c.AircraftModel.Equals(parentAircraft.Model))
				.ToList();
            for (int i = 0; i < categories.Count && i < 4; i++)categoryNames[i] = categories[i].Category;

            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
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
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, 
                                                                                OperatorLogotype, 
                                                                                _filterSelection, 
                                                                                DateAsOf, 
                                                                                reportFooter, 
                                                                                reportFooterPrepared, 
                                                                                reportFooterLink,
                                                                                categoryNames[0],
                                                                                categoryNames[1],
                                                                                categoryNames[2],
                                                                                categoryNames[3],
                                                                                averageUtilizationCycles,
                                                                                averageUtilizationHours,
                                                                                averageUtilizationType);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(LLPDiskSheetDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(LLPDiskSheetDataSet destinationDataSet)
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
