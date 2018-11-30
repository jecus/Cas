using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CASReports.Builders
{
    public class ComponentsReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private string _reportTitle = "COMPONENTS";
        private string _filterSelection;
        private byte[] _operatorLogotype;
        private Aircraft _reportedAircraft;
		private WorkPackage _reportedWorkPackage;
        private Operator _reportedOperator;
        private IEnumerable<IBaseEntityObject> _reportedItems;

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Forecast _forecast;
        private string _dateAsOf = "";
        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;

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
                if (value == null) return;
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
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

        #region public CommonFilterCollection FilterSelection

        /// <summary>
        /// фильтры отчета
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

        #region public Image OperatorLogotype

        /// <summary>
        /// Возвращает или устанавливает логтип эксплуатанта
        /// </summary>
        public byte[] OperatorLogotype
        {
            set
            {
                _operatorLogotype = value;
            }
        }

        #endregion

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// Рабочий пакет по которому строится workscope
        /// </summary>
        public WorkPackage WorkPackage
        {
            set
            {
                _reportedWorkPackage = value;
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

		#region public public ForecastKitsReportBuilder(Aircraft reportedAircraft, IEnumerable<Component> items)

		public ComponentsReportBuilder(Aircraft reportedAircraft, IEnumerable<IBaseEntityObject> items)
        {
            _reportedAircraft = reportedAircraft;

            if (_reportedAircraft != null)
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

            _reportedItems = items;
        }
		#endregion

		#region public ForecastKitsReportBuilder(WorkPackage reportedWorkPackage, IEnumerable<IBaseEntityObject> items)

		public ComponentsReportBuilder(WorkPackage reportedWorkPackage, IEnumerable<IBaseEntityObject> items)
	    {
		    _reportedWorkPackage = reportedWorkPackage;

			if(_reportedWorkPackage.Aircraft != null)
				_reportedAircraft = _reportedWorkPackage.Aircraft;

			if (_reportedWorkPackage != null)
			    _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

		    _reportedItems = items;
	    }

	    #endregion


		#region Methods

        #region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        {
			if (_reportedWorkPackage != null)
			{
				_filterSelection = $"Work Package: {_reportedWorkPackage.Title}";
				if (filterCollection == null || filterCollection.IsEmpty)
					return;
				_filterSelection = $"{_filterSelection} {filterCollection}";
			}
			else if (_reportedAircraft != null)
            {
                _filterSelection = "All";
                if (filterCollection == null || filterCollection.IsEmpty) 
                    return;
                _filterSelection = filterCollection.ToStrings();
            }
            else
            {
                _filterSelection = "All";
            }

        }
        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            var report = new ComponentsReport();
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
            var dataset = new ComponentsDataSet();
            AddAircraftToDataset(dataset);
	        AddComponentsDataset(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

		#endregion

		private void AddComponentsDataset(ComponentsDataSet dataset)
		{
			var components = _reportedItems.Where(i => i is Component).Cast<Component>().GroupBy(c => c.PartNumber);
			var componentDirectives = _reportedItems.Where(i => i is ComponentDirective).Cast<ComponentDirective>().GroupBy(c => c.PartNumber);

			foreach (var grouped in components)
			{
				var component = grouped.First();

				dataset.ItemDataTable.AddItemDataTableRow(component.Description,
					component.CostNew, component.PartNumber,
					component.GoodsClass.ToString(), component.SmartCoreType.ToString(),
					grouped.Count(), component.WorkType.ToString());
			}

			foreach (var grouped in componentDirectives)
			{
				var componentDirective = grouped.First();

				dataset.ItemDataTable.AddItemDataTableRow(componentDirective.Description,
					componentDirective.Cost, componentDirective.PartNumber,
					componentDirective.GoodsClass.ToString(), componentDirective.SmartCoreType.ToString(),
					grouped.Count(), componentDirective.DirectiveType.ToString());
			}
		}

		#region private void AddAircraftToDataset(ForecastKitsDataSet destinationDataSet)

		/// <summary>
		/// Добавляется элемент в таблицу данных
		/// </summary>
		/// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
		private void AddAircraftToDataset(ComponentsDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
            {
                destinationDataSet.AircraftDataTable.AddAircraftDataTableRow("", "", -1, -1,
                                                                             "", "", "", "",
                                                                             -1, -1, "");
                return;
            }

            var reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ToString();
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
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
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(ForecastKitsDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(ComponentsDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected virtual void AddForecastToDataSet(ForecastKitsDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(ComponentsDataSet destinationDataSet)
        {
            ForecastData fd = _forecast != null ? _forecast.GetForecastDataFrame() : null;
            if(fd == null)
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
                if(fd.NextPerformanceByDate)
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