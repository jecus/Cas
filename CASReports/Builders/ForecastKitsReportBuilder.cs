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
    public class ForecastKitsReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private string _reportTitle = "EQUIPMENT & MATERIALS";
        private string _filterSelection;
        private byte[] _operatorLogotype;
        private Aircraft _reportedAircraft;
		private WorkPackage _reportedWorkPackage;
		private BaseComponent _reportedBaseComponent;
        private WorkPackage _workPackage;
        private Operator _reportedOperator;
        private IEnumerable<AbstractAccessory> _reportedDirectives;

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
                _reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
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
                _workPackage = value;
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

        #region public public ForecastKitsReportBuilder(Aircraft reportedAircraft, IEnumerable<AbstractAccessory> performances)

        public ForecastKitsReportBuilder(Aircraft reportedAircraft, IEnumerable<AbstractAccessory> performances)
        {
            _reportedAircraft = reportedAircraft;

            if (_reportedAircraft != null)
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

            _reportedDirectives = performances;
        }
		#endregion

		#region public ForecastKitsReportBuilder(WorkPackage reportedWorkPackage, IEnumerable<AbstractAccessory> performances)

		public ForecastKitsReportBuilder(WorkPackage reportedWorkPackage, IEnumerable<AbstractAccessory> performances)
	    {
		    _reportedWorkPackage = reportedWorkPackage;

			if(_reportedWorkPackage.Aircraft != null)
				_reportedAircraft = _reportedWorkPackage.Aircraft;

			if (_reportedWorkPackage != null)
			    _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

		    _reportedDirectives = performances;
	    }

	    #endregion


		#region Methods

		#region private string GetAccessoryTypeString(AbstractAccessory accessory)

		private string GetAccessoryTypeString(AbstractAccessory accessory)
        {
            return accessory.GoodsClass.ToString();
        }
        #endregion

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
			else if (_reportedBaseComponent != null)
			{
				_filterSelection = "All";
				if (filterCollection == null || filterCollection.IsEmpty) return;
				if (_reportedBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
					_filterSelection = _reportedBaseComponent.TransferRecords.GetLast().Position;
				if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Engine)
					_filterSelection = BaseComponentType.Engine + " " + _reportedBaseComponent.TransferRecords.GetLast().Position;
				if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Apu)
					_filterSelection = BaseComponentType.Apu.ToString();
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
            ForecastKitsReport report = new ForecastKitsReport();
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
            ForecastKitsDataSet dataset = new ForecastKitsDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(ForecastKitsDataSet dataset)
        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(ForecastKitsDataSet dataset)
        {
            //группировка по родительскому самолету
            IEnumerable<IGrouping<Product, AbstractAccessory>> products =
                _reportedDirectives.GroupBy(ak => ak.Product ??
                                                   new Product
                                                   {
                                                       GoodsClass = ak.GoodsClass,
                                                       Standart = ak.Standart,
                                                       PartNumber = ak.ParentString,
                                                       Description = ak.Description
                                                   });
            foreach (IGrouping<Product, AbstractAccessory> product in products)
            {
                string type = GetAccessoryTypeString(product.First());
                double quantity = 0;
                double totalProductCost = 0;

                if (product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools) ||
                    product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ProductionAuxiliaryEquipment))
                {
                    quantity = product.Max(p => p.Quantity);
                    totalProductCost = 0;
                }
                else if (product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
                {
                    foreach (AbstractAccessory accessoryRequired in product)
                    {
                        int qty = accessoryRequired.Quantity < 1 ? 1 : (int) accessoryRequired.Quantity;
                        quantity += qty;
                        totalProductCost += (qty*accessoryRequired.CostNew);
                    }
                }
                else
                {
                    foreach (AbstractAccessory accessoryRequired in product)
                    {
                        quantity += accessoryRequired.Quantity;
                        totalProductCost += (accessoryRequired.Quantity*accessoryRequired.CostNew);
                    }
                }

                dataset.KitsTable.AddKitsTableRow(product.Key.ToString(),
                                                  $"{Math.Round(quantity, 2)} {product.Key.Measure.ShortName}",
                                                  totalProductCost,
                                                  _reportedAircraft != null ? _reportedAircraft + " " + _reportedAircraft.Model : "Unk",
                                                  type);
            }
        }
        #endregion

        #region private void AddAircraftToDataset(ForecastKitsDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(ForecastKitsDataSet destinationDataSet)
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
        private void AddAdditionalDataToDataSet(ForecastKitsDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected virtual void AddForecastToDataSet(ForecastKitsDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(ForecastKitsDataSet destinationDataSet)
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
                    forecastDate =
	                    $"{fd.CheckName}. {SmartCore.Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(fd.NextPerformance.PerformanceDate))}";    
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