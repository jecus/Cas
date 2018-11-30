using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по бортовому журналу ВС
    /// </summary>
    public class MonthlyUtilizationBuilder : AbstractReportBuilder
    {

        #region Fields

        protected readonly Aircraft _currentAircraft;
        private List<AircraftFlight> _currentFlights = new List<AircraftFlight>();
        private readonly Lifelength _summaryLifelength=new Lifelength();
        protected DateTime _periodFrom;
        protected DateTime _periodTo;
        protected double _totalHoursClear;
        protected double _totalCyclesClear;
        protected BaseComponent _engine1;
        protected BaseComponent _engine2;
        protected BaseComponent _apu;
        //private ICommonCollection<ATLB> _atbs;

        #endregion

        #region Constructor

        #region public MonthlyUtilizationBuilder(Aircraft aircraft)

        /// <summary>
        /// Создается построитель отчета по MonthlyUtilization
        /// </summary>
        public MonthlyUtilizationBuilder(Aircraft aircraft, DateTime periodFrom, DateTime periodTo,
                                         double totalHoursClear, double totalCyclesClear)
        {
            _currentAircraft = aircraft;
            _periodFrom = periodFrom;
            _periodTo = periodTo;
            _totalHoursClear = totalHoursClear;
            _totalCyclesClear = totalCyclesClear;

            if(_summaryLifelength.Cycles==null)_summaryLifelength.Cycles = 0;
            if (_summaryLifelength.TotalMinutes == null) _summaryLifelength.TotalMinutes = 0;

            var engines = GlobalObjects.ComponentCore.GetAircraftEngines(_currentAircraft.ItemId);
            if (engines.Length > 0)
                _engine1 = engines[0];
            if (engines.Length > 1)
                _engine2 = engines[1];
            _apu = GlobalObjects.ComponentCore.GetAircraftApu(_currentAircraft.ItemId);
            //_atbs = atlbCollection;
        }

        #endregion

        #endregion
        
        #region Properties

        #region public List<AircraftFlight> Flights

        /// <summary>
        /// Возвращает или иустанавливает отображаемые полеты
        /// </summary>
        public List<AircraftFlight> Flights
        {
            protected get { return _currentFlights; }
            set
            {
                _currentFlights = value;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MonthlyUtilizationReport report = new MonthlyUtilizationReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected MonthlyUtilizationDataSet GenerateDataSet()

        protected MonthlyUtilizationDataSet GenerateDataSet()
        {
            MonthlyUtilizationDataSet dataSet = new MonthlyUtilizationDataSet();
            AddAdditionalDataToDataSet(dataSet);
            AddAircraftToDataset(dataSet);
            AddFlights(dataSet);
            return dataSet;
        }

        #endregion

        #region protected virtual void AddAdditionalDataToDataSet(MonthlyUtilizationDataSet destinationDateSet, bool addRegistrationNumber)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected virtual void AddAdditionalDataToDataSet(MonthlyUtilizationDataSet destinationDateSet)
        {
            var reportHeader = _currentAircraft.RegistrationNumber + ". Monthly Utilization";
            var model = _currentAircraft.Model.ToString();
            var dateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(reportHeader, GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge, dateAsOf, model, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddAircraftToDataset(MonthlyUtilizationDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddAircraftToDataset(MonthlyUtilizationDataSet destinationDataSet)
        {
	        var aircraftLifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircraft);
			var serialNumber = _currentAircraft.SerialNumber;
            var manufactureDate = _currentAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var sinceNewHours = aircraftLifelength.Hours.ToString();
            var sinceNewCycles = aircraftLifelength.Cycles.ToString().Trim();
            var registrationNumber = _currentAircraft.RegistrationNumber;
            string lineNumber;
            string variableNumber;
            string lineNumberCaption = "";
            string variableNumberCaption = "";
            string averageUtilizationHoursPlan;
            string averageUtilizationCyclesPlan;
            string averageUtilizationPlanType;
            string averageUtilizationHoursFact;
            string averageUtilizationCyclesFact;
            string averageUtilizationFactType;
            string selection;

            string engineCaption1 = "";
            string engineCaption2 = "";
            string apuCaption = "";

	        var engine = GlobalObjects.ComponentCore.GetAircraftEngines(_currentAircraft.ItemId);
			var apu = GlobalObjects.ComponentCore.GetAircraftApu(_currentAircraft.ItemId);

			if (engine[0]!= null)
                engineCaption1 = "Engine " + engine[0].PositionNumber + "\r\nS/N: " +
									engine[0].SerialNumber;
            if (engine[1] != null)
                engineCaption2 = "Engine " + engine[1].PositionNumber + "\r\nS/N: " +
									engine[1].SerialNumber;
            if (apu != null)
                apuCaption = "APU" + "\r\nS/N: " + apu.SerialNumber;

            //вычисление периода в днях
            int periodDays = (_periodTo - _periodFrom).Days;
            //вычисление сред. кол-ва часов в день
            double avgHoursPerDay = _totalHoursClear / periodDays;
            //вычисление сред. кол-ва циклов в день
            double avgCyclesPerDay = _totalCyclesClear / periodDays;
			//плановая утилизация
			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_currentAircraft.AircraftFrameId);
			var plan = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
			//вычисление фактической утилизации
			AverageUtilization factPerPeriod;

            if (plan.SelectedInterval == UtilizationInterval.Dayly)
            {
                factPerPeriod = new AverageUtilization(avgCyclesPerDay, avgHoursPerDay,
                                                       UtilizationInterval.Dayly);
            }
            else
            {
                factPerPeriod = new AverageUtilization(avgCyclesPerDay * 30, avgHoursPerDay * 30,
                                                       UtilizationInterval.Monthly);
            }

            averageUtilizationHoursPlan = plan.Hours.ToString();
            averageUtilizationCyclesPlan = plan.Cycles.ToString();
            averageUtilizationPlanType = plan.SelectedInterval == UtilizationInterval.Dayly ? "DAY" : "MONTH";

            const string specifier = "G3";
            CultureInfo culture = CultureInfo.CreateSpecificCulture("eu-ES");
            averageUtilizationHoursFact = factPerPeriod.Hours.ToString(specifier, culture);
            averageUtilizationCyclesFact = factPerPeriod.Cycles.ToString(specifier,culture);
            averageUtilizationFactType = factPerPeriod.SelectedInterval == UtilizationInterval.Dayly ? "DAY" : "MONTH";

            selection = SmartCore.Auxiliary.Convert.DatePeriodToString(_periodFrom, _periodTo);

                lineNumber = (_currentAircraft).LineNumber;
                variableNumber = (_currentAircraft).VariableNumber;
                if (lineNumber != "")
                    lineNumberCaption = "L/N:";
                if (variableNumber != "")
                    variableNumberCaption = "V/N:";
            
            destinationDataSet.BaseDetailTable.AddBaseDetailTableRow(serialNumber,
                                                                     manufactureDate, sinceNewHours, sinceNewCycles, 
                                                                     registrationNumber, lineNumber, variableNumber, lineNumberCaption, variableNumberCaption,
                                                                     averageUtilizationHoursPlan, averageUtilizationHoursFact, averageUtilizationCyclesPlan, averageUtilizationCyclesFact,
                                                                     engineCaption1, "", engineCaption2, "", apuCaption, "", averageUtilizationPlanType, averageUtilizationFactType, selection);
        }

        #endregion

        #region private void AddFlights(MonthlyUtilizationDataSet dataSet)

        private void AddFlights(MonthlyUtilizationDataSet dataSet)
        {
            string currentGroupName="";
            int counter = 0;
            
            for (int i = 0; i < Flights.Count; i++)
            {
                string groupName = Flights[i].FlightDate.ToString("MMMM yyyy", CultureInfo.CurrentCulture);
                if (groupName != currentGroupName)
                {
                    currentGroupName = groupName;
                    counter = 1;
                }
                else
                    counter++;
                AddFlight(dataSet, Flights[i],currentGroupName,counter);
            }
        }

        #endregion

        #region protected virtual void AddFlight(MonthlyUtilizationDataSet dataSet, AircraftFlight aircraftFlight)

        protected virtual void AddFlight(MonthlyUtilizationDataSet dataSet, AircraftFlight item, string groupName,int counter)
        {
			//TODO: (Evgenii Babak) сравнить подход в этом методе с подходом в MonthlyutilizationListView. Нужно вынести в отдельный метод BL
            var dateString = item.FlightDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var route = item.StationFromId.ShortName + " - " + item.StationToId.ShortName;
            var flightTimeString = UsefulMethods.TimeToString(new TimeSpan(0, 0, item.FlightTimeTotalMinutes, 0)) + " (" +
                                   UsefulMethods.TimePeriodToString(new TimeSpan(0, 0, item.TakeOffTime, 0),
                                                                    new TimeSpan(0, 0, item.LDGTime, 0)) + ")";
            var perDays = Lifelength.Zero;
            var flights = _currentFlights.Where(f => f.FlightDate.Date.AddMinutes(f.TakeOffTime) <=
                                                                      item.FlightDate.Date.AddMinutes(item.TakeOffTime)).ToList();
            foreach (var aircraftFlight in flights)
                perDays.Add(aircraftFlight.FlightTimeLifelength);
            var aircraftLifelenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(item);

            #region колонки для отображения наработок по двигателям и ВСУ

            var engine1 = "";
            var engine2 = "";
            var apu = "";
            if (_engine1 != null)
	            engine1 = GetFlightLifelengthStringForBaseDetail(_engine1, item);
            if (_engine2!= null)
				engine2 = GetFlightLifelengthStringForBaseDetail(_engine2, item);
            if (_apu != null)
				apu = GetFlightLifelengthStringForBaseDetail(_apu, item);

            #endregion

            var color=UsefulMethods.GetColorName(item);
            if (!item.Correct) color = "White";
            //if(color=="") color = aircraftFlight.Highlight.Name;


            dataSet.Items.AddItemsRow(dateString, 
                                      item.FlightNumber.ToString(), 
                                      route, 
                                      "",
                                      item.Reference, 
                                      item.PageNo,
                                      "",
                                      "",
                                      "1",
                                      flightTimeString,
                                      perDays.ToHoursMinutesAndCyclesFormat("", ""), 
                                      aircraftLifelenght.ToHoursMinutesAndCyclesFormat("", ""), 
                                      "",
                                      groupName, 
                                      counter.ToString(), engine1, "", engine2, "", apu, "", color);
        }

		#endregion


		#region private string GetFlightLifelengthStringForBaseDetail(BaseDetail detail, AircraftFlight flight)

		private string GetFlightLifelengthStringForBaseDetail(BaseComponent component, AircraftFlight flight)
	    {
		    var lastKnownTransferRecBeforFlight = component.TransferRecords.GetLastKnownRecord(flight.FlightDate.Date);
		    if (lastKnownTransferRecBeforFlight != null)
		    {
			    if (flight.FlightDate.Date > lastKnownTransferRecBeforFlight.RecordDate.Date)
				    return
					    GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(component, flight)
						    .ToHoursMinutesAndCyclesFormat("", "");
		    }
		    return "";
	    }

	    #endregion


		#endregion
	}
}
