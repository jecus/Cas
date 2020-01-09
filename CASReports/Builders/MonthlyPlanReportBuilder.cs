using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;
using Convert = System.Convert;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по плану работ на месяц
    /// </summary>
    public class MonthlyPlanReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private Aircraft _reportedAircraft;
        private readonly Operator _reportedOperator;
        private IEnumerable<NextPerformance> _reportedDirectives;
        private Forecast _forecast;
        private string _dateAsOf = "";

        private string _reportTitle = "SCHEDULED";
        private string _filterSelection = "All";
        private byte[] _operatorLogotype;

		#endregion

		#region Properties

		#region public Forecast Forecast

		public Forecast Forecast
		{
			set { _forecast = value; }
		}
		#endregion

		#endregion

		#region public MonthlyPlanReportBuilder(IEnumerable<NextPerformance> performances)

		public MonthlyPlanReportBuilder(Operator @operator, IEnumerable<NextPerformance> performances)
        {
            _reportedOperator = @operator;

            if (_reportedOperator != null)
                _operatorLogotype = _reportedOperator.LogotypeReportLarge;

            _reportedDirectives = performances;
        }
        #endregion

        #region public MonthlyPlanReportBuilder(IEnumerable<NextPerformance> performances)

        public MonthlyPlanReportBuilder(Aircraft reportedAircraft, IEnumerable<NextPerformance> performances)
        {
            _reportedAircraft = reportedAircraft;

            if (_reportedAircraft != null)
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

            _reportedDirectives = performances;
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

		#region Methods

		#region public override object GenerateReport()

		/// <summary>
		/// Сгенерируовать отчет по данным, добавленным в текущий объект
		/// </summary>
		/// <returns>Построенный отчет</returns>
		public override object GenerateReport()
        {
            MonthlyPlanReport report = new MonthlyPlanReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private IBaseEntityObject GetParent(NextPerformance np)

        private string GetParent(NextPerformance np)
        {
            IBaseEntityObject parent = np.Parent;
            var destination = "";

            if (parent is Directive)
            {
                var dir = (Directive)parent;
	            destination = GetDestination(dir.ParentBaseComponent.ParentAircraftId, dir.ParentBaseComponent.ParentStoreId);
            }
            else if (parent is Component)
            {
                var d = (Component)parent;
				destination = GetDestination(d.ParentBaseComponent.ParentAircraftId, d.ParentStoreId);
            }
            else if (parent is ComponentDirective)
            {
                var dd = (ComponentDirective)parent;

                if (dd.ParentComponent != null)
					destination = GetDestination(dd.ParentBaseComponent.ParentAircraftId, dd.ParentBaseComponent.ParentAircraftId);
            }
            else if (parent is MaintenanceCheck)
            {
                var mc = (MaintenanceCheck)parent;
                destination = $"{mc.ParentAircraft.RegistrationNumber} {mc.ParentAircraft.Model}";//TODO:(Evgenii Babak) заменить на использование AircraftCore
			}
            else if (parent is MaintenanceDirective)
            {
                var md = (MaintenanceDirective)parent;
				destination = GetDestination(md.ParentBaseComponent.ParentAircraftId, md.ParentBaseComponent.ParentStoreId);
            }
            return destination;
        }
        #endregion

        #region public virtual MonthlyPlanDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual MonthlyPlanDataSet GenerateDataSet()
        {
            MonthlyPlanDataSet dataset = new MonthlyPlanDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

		#endregion


		#region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
		protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
		{
			if (_reportedAircraft != null)
			{
				_filterSelection = "All";
				if (filterCollection == null || filterCollection.IsEmpty)
					return;
				_filterSelection = filterCollection.ToStrings();
			}
			else
			{
				IEnumerable<IGrouping<Aircraft, NextPerformance>> groupByAircraft =
					_reportedDirectives.GroupBy(GlobalObjects.AircraftsCore.GetParentAircraft)
									   .OrderBy(g => g.Key.ToString() + " " + g.Key.Model.ToString());

				_filterSelection = "All";
				if (GlobalObjects.AircraftsCore.GetAircraftsCount() == groupByAircraft.Count())
				{
					if (filterCollection == null || filterCollection.IsEmpty)
						return;
					_filterSelection = filterCollection.ToStrings();
				}					
				else
				{
					foreach (IGrouping<Aircraft, NextPerformance> byAircraft in groupByAircraft)
					{
						_filterSelection += (byAircraft.Key + "; ");
					}
					if (filterCollection == null || filterCollection.IsEmpty)
						return;
					_filterSelection = $"{_filterSelection} {filterCollection}";
				}
			}
		}
		#endregion

		#region protected virtual void AddDirectivesToDataSet(MonthlyPlanDataSet dataset)

		/// <summary>
		/// Добавление директив в таблицу данных
		/// </summary>
		/// <param name="dataset">Таблица, в которую добавляются данные</param>
		protected virtual void AddDirectivesToDataSet(MonthlyPlanDataSet dataset)
        {
            //Группировка элементов по датам выполнения
            IEnumerable<IGrouping<DateTime, NextPerformance>> groupedItems =
                _reportedDirectives.GroupBy(np => Convert.ToDateTime(np.PerformanceDate).Date)
                                   .OrderBy(g => g.Key);

            foreach (IGrouping<DateTime, NextPerformance> groupedItem in groupedItems)
            {
                DateTime dateTime = groupedItem.Key.Date;
                string dateString = groupedItem.Key.Date > DateTimeExtend.GetCASMinDateTime().Date
                    ? SmartCore.Auxiliary.Convert.GetDateFormat(groupedItem.Key.Date) + " "
                    : "";
                //группировка по родительскому самолету
                IEnumerable<IGrouping<string, NextPerformance>> groupByAircraft =
                    groupedItem.GroupBy(GetParent)
                               .OrderBy(g => g.Key.ToString());

                foreach (IGrouping<string, NextPerformance> byAircraft in groupByAircraft)
                {
                    //Формирование первой части названия группы, состоящей из даты выполнения
                    string temp = "";
                    //Собрание всех выполнений на данную дату в одну коллекцию
                    IEnumerable<NextPerformance> performances = byAircraft.Select(lvi => lvi);
                    //Добавление в название присутствующих на данную дату чеков программы обслуживания
                    IEnumerable<NextPerformance> maintenanceCheckPerformances =
                        performances.Where(np => np.Parent != null && np.Parent is MaintenanceCheck);
                    foreach (NextPerformance maintenanceCheckPerformance in maintenanceCheckPerformances)
                    {
                        if (maintenanceCheckPerformance is MaintenanceNextPerformance)
                        {
                            MaintenanceNextPerformance mnp = maintenanceCheckPerformance as MaintenanceNextPerformance;
                            temp += mnp.PerformanceGroup.GetGroupName();
                        }
                        else temp += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name;
                        temp += " ";
                    }

                    //Добавление в название присутствующих на данную дату директив летной годности
                    IEnumerable<NextPerformance> adPerformances =
                        performances.Where(np => np.Parent != null && np.Parent is Directive);
                    if (adPerformances.Count() > 0)
                        temp += "AD ";

                    //Добавление в название присутствующих на данную дату компонентов или задач по ним
                    IEnumerable<NextPerformance> componentPerformances =
                        performances.Where(np => np.Parent != null && (np.Parent is Component || np.Parent is ComponentDirective));
                    if (componentPerformances.Count() > 0)
                        temp += "Comp ";

                    //Добавление в название присутствующих на данную дату MPD
                    IEnumerable<NextPerformance> mpdPerformances =
                        performances.Where(np => np.Parent != null && np.Parent is MaintenanceDirective);
                    if (maintenanceCheckPerformances.Count() == 0 && mpdPerformances.Count() > 0)
                        temp += "MPD ";

                    string destinationString = byAircraft.Key;


                    dataset.ItemsTable.AddItemsTableRow(dateString, destinationString, temp, dateTime.Ticks, destinationString);
                }
            }
        }

        #endregion

        #region private void AddAircraftToDataset(MonthlyPlanDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MonthlyPlanDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
            {
                destinationDataSet.AircraftDataTable.AddAircraftDataTableRow("", "", -1, -1,
                                                                             "", "", "", "",
                                                                             -1, -1, "");
                return;
            }

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

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
                                                                         averageUtilizationHours, averageUtilizationCycles, $"{averageUtilizationHours}FH\\{averageUtilizationCycles}FC\\{averageUtilizationType}");//TODO:если в отчете сделать точно такую же строку то она при сохранении слетает(так и не нашел причину почему)
        }

        #endregion

        #region public void AddDirectiveToDataset(object MaintenanceCheck, MaintenanceProgramDataSet destinationDataSet)

        ///// <summary>
        ///// Добавляется элемент в таблицу данных
        ///// </summary>
        ///// <param name="reportedDirective">Добавлямая директива</param>
        ///// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        //private void AddDirectiveToDataset(MaintenanceCheck reportedDirective, MaintenanceProgramDataSet destinationDataSet)
        //{
        //    //if (!DefaultFilter.Acceptable(directive))
        //    //  return;
        //    string remarks, hiddenRemark = "";
        //    Lifelength lastCompliance = Lifelength.Null,
        //               repeatInterval = Lifelength.Null,
        //               nextCompliance = Lifelength.Null,
        //               remain = Lifelength.Null;
        //    string lastComplianceDate = "", nextComplianceDate;
        //    Lifelength used = Lifelength.Null;

        //    remarks = reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.Remarks : "";
        //        //расчет остатка от выполнения с даты производтсва
        //    Lifelength next;
        //    DateTime? approximate;
        //    Lifelength remains;
        //    ConditionState condition;
        //    GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(reportedDirective, new List<MaintenanceCheck>(_reportedDirectives.ToArray()), out next, out remains,
        //                                                 out approximate, out condition,
        //                                                 _reportedAircraft.AverageUtilization);
        //    if (reportedDirective.LastPerformance != null)
        //    {
        //        if (reportedDirective.Interval != null) repeatInterval = reportedDirective.Interval;

        //        lastComplianceDate =
        //                reportedDirective.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
        //        lastCompliance =
        //            GlobalObjects.CasEnvironment.Calculator.GetLifelength(_reportedAircraft.Frame, reportedDirective.LastPerformance.RecordDate);

        //        used.Add(_current);
        //        used.Substract(lastCompliance);

        //        if (next != null)
        //        {
        //            remain.Add(next);
        //            remain.Substract(_current);
        //            remain.Resemble(reportedDirective.Interval);
        //        }
        //    }

        //    nextComplianceDate = approximate != null
        //                                 ? ((DateTime)approximate).ToString(
        //                                     new GlobalTermsProvider()["DateFormat"].ToString())
        //                                 : "";
        //    nextCompliance = next ?? Lifelength.Null;

        //    destinationDataSet.ItemsTable.AddItemsTableRow(remarks,
        //                                                   hiddenRemark,
        //                                                   "",
        //                                                   reportedDirective.Name,
        //                                                   repeatInterval.Days != null ? repeatInterval.Days.ToString(): "",
        //                                                   repeatInterval.Hours != null ? repeatInterval.Hours.ToString() : "",
        //                                                   repeatInterval.Cycles != null ? repeatInterval.Cycles.ToString() : "",
        //                                                   lastComplianceDate,
        //                                                   lastCompliance.Hours != null ? lastCompliance.Hours.ToString() : "",
        //                                                   lastCompliance.Cycles != null ? lastCompliance.Cycles.ToString() : "",
        //                                                   used.Days != null ? used.Days.ToString() : "",
        //                                                   used.Hours != null ? used.Hours.ToString() : "",
        //                                                   used.Cycles != null ? used.Cycles.ToString() : "",
        //                                                   nextComplianceDate,
        //                                                   nextCompliance.Hours != null ? nextCompliance.Hours.ToString() : "",
        //                                                   nextCompliance.Cycles != null ? nextCompliance.Cycles.ToString() : "",
        //                                                   remain.Days != null ? remain.Days.ToString() : "",
        //                                                   remain.Hours!= null ? remain.Hours.ToString() : "",
        //                                                   remain.Cycles != null ? remain.Cycles.ToString() : "",
        //                                                   condition.ToString());
        //}

        #endregion

        #region private void AddAdditionalDataToDataSet(MonthlyPlanDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MonthlyPlanDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected virtual void AddForecastToDataSet(MonthlyPlanDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(MonthlyPlanDataSet destinationDataSet)
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
			var avgUtilizationCycles = (int)fd.AverageUtilization.Cycles;
			var avgUtilizationHours = (int)fd.AverageUtilization.Hours;
			string avgUtilizationType = fd.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
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

		//TODO:(Evgenii Babak) использовать DestinationHelper
	    private string GetDestination(int aircraftId, int storeId)
	    {
			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(aircraftId);
			var parentStore = GlobalObjects.StoreCore.GetStoreById(storeId);

			if (parentAircraft != null)
				return $"{parentAircraft.RegistrationNumber} {parentAircraft.Model}";
		    if (parentStore != null)
			    return $"{parentStore.Name} {parentStore.Location}";

		    return "";
	    }

        #endregion
    }
}