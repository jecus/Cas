using System;
using System.Collections.Generic;
using System.ComponentModel;
using SmartCore.Calculations.Maintenance;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Calculations
{
	public interface ICalculator
	{
		void Reset();
		void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState);

		/*
	    * Расчет дат
	    */

		DateTime GetMaxDate(DateTime dateTime1, DateTime dateTime2);
		DateTime GetManufactureDate(BaseEntityObject source);
		DateTime GetStartDate(IDirective directive);

		/*
         * Подсчет ресурсов
         */
		Lifelength GetCurrentFlightLifelength(BaseEntityObject source, ForecastData forecastData = null);
		Lifelength GetFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate);
		Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate);
		Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, ForecastData forecastData = null);

		/*
	    * Воздушное судно
	    */
		Lifelength GetFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date);
		Lifelength GetFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date);
		Lifelength GetFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate);
		Lifelength GetFlightLifelengthIncludingThisFlight(AircraftFlight flight);
		Lifelength GetCurrentFlightLifelength(Aircraft aircraft);

		/*
	    * Базовый агрегат
	    */
		Lifelength GetFlightLifelengthIncludingThisFlight(BaseComponent baseComponent, AircraftFlight flight);
		Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date);
		Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date, FlightRegime flightRegime);
		Lifelength GetCurrentFlightLifelength(BaseComponent baseComponent);
		Lifelength GetFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate);
		Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate);
		Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate, FlightRegime flightRegime);
		Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd);
		Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd, FlightRegime flightRegime);


		/*
	    * Агрегат
	    */
		Lifelength GetCurrentFlightLifelength(Entities.General.Accessory.Component component);
		Lifelength GetFlightLifelengthOnEndOfDay(Entities.General.Accessory.Component component, DateTime effectiveDate);

		/*
	    * AircraftFlights 
	    */
		double GetTotalHours(AircraftFlightCollection flights);
		int GetTotalCycles(AircraftFlightCollection flights);


		/*
	    * Директивы 
	    */

		/*
         * Калькуляция наработки для записей о выполнении задачи
         */
		Lifelength GetFlightLifelengthOnEndOfDay(DirectiveRecord record);
		Lifelength GetFlightLifelengthOnEndOfDay(TransferRecord record);

		/*
         * Расчет выполнения задачи
         */

		/*
         *  Maintenance
         */

		bool IsEqual(double x, double y);
		void ResetMath(Aircraft aircraft);

		void ResetMath(BaseComponent baseComponent);

		void LoadCalculator();
	}
}
