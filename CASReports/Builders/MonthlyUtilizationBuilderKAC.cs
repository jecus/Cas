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
using SmartCore.Entities.General.Atlbs;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по бортовому журналу ВС
    /// </summary>
    public class MonthlyUtilizationBuilderKAC : MonthlyUtilizationBuilder
    {

        #region Fields

        #endregion

        #region Constructor

        #region public MonthlyUtilizationBuilderKAC(Aircraft aircraft)

        /// <summary>
        /// Создается построитель отчета по MonthlyUtilization
        /// </summary>
        public MonthlyUtilizationBuilderKAC(Aircraft aircraft, DateTime periodFrom, DateTime periodTo,
                                            double totalHoursClear, double totalCyclesClear) 
            : base(aircraft,periodFrom, periodTo, totalHoursClear, totalCyclesClear)
        {
        
        }

        #endregion

        #endregion
        
        #region Properties

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MonthlyUtilizationReportKAC report = new MonthlyUtilizationReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override void AddAdditionalDataToDataSet(MonthlyUtilizationDataSet destinationDateSet, bool addRegistrationNumber)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected override void AddAdditionalDataToDataSet(MonthlyUtilizationDataSet destinationDateSet)
        {
            var reportHeader = "Aircraft Utilization Report";
            var model = _currentAircraft.Model.ShortName;
            var dateAsOf = DateTime.Today.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(reportHeader, GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge, dateAsOf, model, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected override void AddAircraftToDataset(MonthlyUtilizationDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected override void AddAircraftToDataset(MonthlyUtilizationDataSet destinationDataSet)
        {
	        var aircraftLifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_currentAircraft);
			string serialNumber = _currentAircraft.SerialNumber;
            string manufactureDate = _currentAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string sinceNewHours = aircraftLifelength.ToHoursMinutesFormat("");
            string sinceNewCycles = aircraftLifelength.Cycles.ToString().Trim();
            string registrationNumber = _currentAircraft.RegistrationNumber;
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
            string engineCaption1FC = "";
            string engineCaption2 = "";
            string engineCaption2FC = "";
            string apuCaption = "";
            string apuCaptionFC = "";
            if(_engine1!= null)
            {
                engineCaption1 = "E1 TT " + "\r\nS/N \r\n" + _engine1.SerialNumber;
                engineCaption1FC = "E1 TC ";
            }
            if (_engine2 != null)
            {
                engineCaption2 = "E2 TT " + "\r\nS/N \r\n" + _engine2.SerialNumber;
                engineCaption2FC = "E2 TC ";
            }
            if (_apu!= null)
            {
                apuCaption = "APU TT";
                apuCaptionFC = "APU FC";
            }

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
                                                                     engineCaption1, engineCaption1FC, engineCaption2, engineCaption2FC, apuCaption, apuCaptionFC, averageUtilizationPlanType, averageUtilizationFactType, selection);
        }

        #endregion

        #region protected override void AddFlight(MonthlyUtilizationDataSet dataSet, AircraftFlight aircraftFlight)

        protected override void AddFlight(MonthlyUtilizationDataSet dataSet, AircraftFlight item, string groupName,int counter)
        {
            string dateString =  SmartCore.Auxiliary.Convert.GetDateFormat(item.FlightDate);
            Lifelength perDays = Lifelength.Zero;
            List<AircraftFlight> flights = Flights.Where(f => f.FlightDate.Date.AddMinutes(f.TakeOffTime) <=
                                                              item.FlightDate.Date.AddMinutes(item.TakeOffTime)).ToList();
            foreach (AircraftFlight aircraftFlight in flights)
                perDays.Add(aircraftFlight.FlightTimeLifelength);
            Lifelength aircraftLifelenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(item);

            #region колонки для отображения наработок по двигателям и ВСУ

            Lifelength engine1 = Lifelength.Null;
            Lifelength engine2 = Lifelength.Null;
            Lifelength apu = Lifelength.Null;
            if (_engine1 != null)
            {
                engine1 = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(_engine1, item);
            }
            if (_engine2!= null)
            {
                engine2 = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(_engine2, item);
            }
            if (_apu != null)
            {
                apu = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthIncludingThisFlight(_apu, item);
            }

            #endregion

            string color=UsefulMethods.GetColorName(item);
            if (!item.Correct) color = "White";

            dataSet.Items.AddItemsRow(dateString, 
                                      item.FlightNumber.ToString(),
                                      item.StationFromId.ShortName,
                                      item.StationToId.ShortName,
                                      item.Reference, 
                                      item.PageNo,
                                      UsefulMethods.TimeToString(new TimeSpan(0, 0, item.TakeOffTime, 0)),
                                      UsefulMethods.TimeToString(new TimeSpan(0, 0, item.LDGTime, 0)),
                                      "1",
                                      UsefulMethods.TimeToString(new TimeSpan(0, 0, item.FlightTimeTotalMinutes, 0)),
                                      perDays.ToHoursMinutesAndCyclesFormat("", ""), 
                                      aircraftLifelenght.ToHoursMinutesFormat(""),
                                      aircraftLifelenght.Cycles != null ? aircraftLifelenght.Cycles.ToString() : "",
                                      groupName, 
                                      counter.ToString(), 
                                      engine1.ToHoursMinutesFormat(""), 
                                      engine1.Cycles != null ? engine1.Cycles.ToString() : "", 
                                      engine2.ToHoursMinutesFormat(""), 
                                      engine2.Cycles != null ? engine2.Cycles.ToString() : "",
                                      apu.ToHoursMinutesFormat(""),
                                      apu.Cycles != null ? apu.Cycles.ToString() : "", 
                                      color);
        }

        #endregion

        #endregion
    }
}
