using System;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using SmartCore.Filters;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчетов для списка директив
    /// </summary>
    public class DeferredListReportBuilder : DirectivesReportBuilder
    {

        #region Fields

        private ForecastData _forecastData;

        #endregion

        #region Properties

        #region public ForecastData ForecastData
       
        public ForecastData ForecastData
        {
            set { _forecastData = value; }
        }
        #endregion

        #endregion

        #region public DeferredListReportBuilder()

        public DeferredListReportBuilder()
        {
            _reportTitle = "DEFERRED ITEMS \nLIST"; 
        }
        #endregion

        #region Methods

        #region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        protected override void GetFilterSelection(CommonFilterCollection filterCollection)
        {
            _filterSelection = "All";
            if(_reportedAircraft == null || filterCollection == null)return;

            foreach (ICommonFilter filter in filterCollection.Filters)
            {
                if (filter is CommonFilter<DeferredCategory>)
                {
                    _filterSelection = "";
                    CommonFilter<DeferredCategory> dcf = (CommonFilter<DeferredCategory>)filter;

                    DefferedCategoriesCollection dcc =
                        GlobalObjects.CasEnvironment.Loader.GetObjectCollection<DeferredCategory, DefferedCategoriesCollection>
                        (new ICommonFilter[]
                             {
                                 new CommonFilter<AircraftModel>(DeferredCategory.AircraftModelProperty, _reportedAircraft.Model)
                             });

                    if (dcf.Values.Length == dcc.Count)
                        _filterSelection = "All";
                    else
                    {
                        foreach (DeferredCategory category in dcf.Values)
                        {
                            if (_filterSelection != "") _filterSelection += ",";
                            _filterSelection += category;
                        }
                    }
                    break;
                }
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
            DefferedListReport report = new DefferedListReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override DataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        protected override DataSet GenerateDataSet()
        {
            DefferedListDataSet dataset = new DefferedListDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(DefferedListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(DefferedListDataSet dataset)
        {
            foreach (DeferredItem t in _reportedDirectives.OfType<DeferredItem>())
            {
                AddDirectiveToDataset(t, dataset);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(DefferedListDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght =
                GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0 ;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var registrationNumber = _reportedAircraft.RegistrationNumber;
            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if(_forecastData == null)
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
                                                                         sinceNewHours, 
                                                                         sinceNewCycles,
                                                                         registrationNumber, lineNumber, variableNumber,
                                                                         averageUtilizationHours,averageUtilizationCycles,averageUtilizationType);
        }

        #endregion

        #region private void AddDirectiveToDataset(DefferedItem directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="directive">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(DeferredItem directive, DefferedListDataSet destinationDataSet)
        {
            GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
            string category = directive.DeferredCategory != null ? directive.DeferredCategory.ToString() :"N/A";
            string discoveryDate = directive.Threshold.EffectiveDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string nextDate = directive.NextPerformanceDate != null
                ? ((DateTime)directive.NextPerformanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                : (directive.LastPerformance != null
                    ? directive.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                    :"");

            string interval = directive.LastPerformance != null
                ? (directive.NextPerformanceDate != null
                    ? directive.Threshold.RepeatInterval.Days.ToString()
                    : directive.Threshold.FirstPerformanceSinceEffectiveDate.Days.ToString())
                : directive.Threshold.FirstPerformanceSinceEffectiveDate.Days.ToString();

            string lastCompliance = directive.LastPerformance != null
                ? directive.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                : "";
            string status = "";
            if (directive.Status == DirectiveStatus.Closed ||
                directive.Status == DirectiveStatus.Open ||
                directive.Status == DirectiveStatus.Repetative ||
                directive.Status == DirectiveStatus.NotApplicable)
                status = directive.Status.ShortName;

            string condition = directive.Condition.ToString();

            string remarks = directive.LastPerformance != null ? directive.LastPerformance.Remarks : "";
           
            destinationDataSet.ItemsTable.AddItemsTableRow(directive.DeferredLogBookRef, 
                                                           directive.DeferredMelCdlItem, 
                                                           directive.Description,
                                                           category, 
                                                           directive.DeferredExtention,
                                                           condition,
                                                           status,
                                                           discoveryDate,
                                                           interval, 
                                                           nextDate,
                                                           lastCompliance,
                                                           remarks);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(DefferedListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(DefferedListDataSet destinationDateSet)
        {
            string model = _reportedBaseComponent != null && _reportedBaseComponent.Model != null 
                ? _reportedBaseComponent.Model.ToString() : 
                _reportedAircraft.Model.ToString();
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, model, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(DefferedListDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(DefferedListDataSet destinationDataSet)
        {
            if (_forecastData  == null)
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
            double avgUtilizationCycles = _forecastData.AverageUtilization.Cycles;
            double avgUtilizationHours = _forecastData.AverageUtilization.Hours;
            string avgUtilizationType = _forecastData.AverageUtilization.SelectedInterval.ToString();
            int forecastCycles = _forecastData.ForecastLifelength.Cycles != null
                                     ? (int)_forecastData.ForecastLifelength.Cycles
                                     : 0;
            int forecastHours = _forecastData.ForecastLifelength.Hours != null
                                    ? (int)_forecastData.ForecastLifelength.Hours
                                    : 0;
            int forecastDays = _forecastData.ForecastLifelength.Days != null
                                   ? (int)_forecastData.ForecastLifelength.Days
                                   : 0;
            string forecastDate = "";

            if (_forecastData.SelectedForecastType == ForecastType.ForecastByDate)
            {
                forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(_forecastData.ForecastDate);
            }
            else if (_forecastData.SelectedForecastType == ForecastType.ForecastByPeriod)
            {
                forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(_forecastData.LowerLimit) + " - " +
                               SmartCore.Auxiliary.Convert.GetDateFormat(_forecastData.ForecastDate);
            }
            else if (_forecastData.SelectedForecastType == ForecastType.ForecastByCheck)
            {
                if (_forecastData.NextPerformanceByDate)
                {
                    forecastDate = _forecastData.NextPerformanceString;
                }
                else
                {
                    forecastDate = string.Format("{0}. {1}",
                        _forecastData.CheckName,
                        SmartCore.Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(_forecastData.NextPerformance.PerformanceDate)));
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