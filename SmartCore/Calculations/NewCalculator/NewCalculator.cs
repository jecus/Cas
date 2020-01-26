using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Providers;

namespace SmartCore.Calculations.NewCalculator
{
	public class NewCalculator : ICalculator
	{
		private readonly CalcProvider _provider;

		public NewCalculator(CalcProvider provider)
		{
			_provider = provider;
		}
		public void Reset()
		{
			throw new NotImplementedException();
		}

		public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
		{
			throw new NotImplementedException();
		}

		public DateTime GetMaxDate(DateTime dateTime1, DateTime dateTime2)
		{
			return new[] {dateTime1, dateTime2}.Max();
		}

		public DateTime GetManufactureDate(BaseEntityObject source)
		{
			return getManufactureDate(source);
		}

		private DateTime getManufactureDate(BaseEntityObject source)
		{
			if (source == null) return DateTimeExtend.GetCASMinDateTime();
			if (source is Aircraft) return ((Aircraft)source).ManufactureDate;
			if (source is BaseComponent) return ((BaseComponent)source).ManufactureDate;
			if (source is Entities.General.Accessory.Component) return ((Entities.General.Accessory.Component)source).ManufactureDate;
			return DateTimeExtend.GetCASMinDateTime();
		}

		public DateTime GetStartDate(IDirective directive)
		{
			if (directive == null || directive.Threshold == null) return DateTimeExtend.GetCASMinDateTime();

			DateTime? sinceNew = null;
			DateTime? sinceEffDate = null;

			if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
			    !directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
			{
				sinceEffDate = directive.Threshold.EffectiveDate;
			}
			if (directive.Threshold.FirstPerformanceSinceNew != null &&
			    !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
			{
				sinceNew = getManufactureDate(directive.LifeLengthParent);
			}

			if (sinceNew != null && sinceEffDate != null)
			{
				if (directive.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst)
				{
					return sinceNew < sinceEffDate ? sinceNew.Value : sinceEffDate.Value;
				}
				return sinceNew > sinceEffDate ? sinceNew.Value : sinceEffDate.Value;
			}
			if (sinceNew != null) return sinceNew.Value;
			if (sinceEffDate != null) return sinceEffDate.Value;
			return DateTimeExtend.GetCASMinDateTime();
		}

		public Lifelength GetCurrentFlightLifelength(BaseEntityObject source, ForecastData forecastData = null)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, ForecastData forecastData = null)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(Aircraft aircraft, DateTime date)
		{
			return _provider.GetFlightLifelengthOnStartOfDayCalculator(aircraft.ItemId, date);
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(Aircraft aircraft, DateTime date)
		{
			return _provider.GetFlightLifelengthOnEndOfDayCalculator(aircraft.ItemId, date);
		}

		public Lifelength GetFlightLifelengthForPeriod(Aircraft aircraft, DateTime fromDate, DateTime toDate)
		{
			return _provider.GetFlightLifelengthForPeriodCalculator(aircraft.ItemId, fromDate, toDate);
		}

		public Lifelength GetFlightLifelengthIncludingThisFlight(AircraftFlight flight)
		{
			return _provider.GetFlightLifelengthIncludingThisFlightCalculator(flight.ItemId);
		}

		public Lifelength GetCurrentFlightLifelength(Aircraft aircraft)
		{
			return _provider.GetCurrentFlightLifelengthCalculator(aircraft.ItemId);
		}

		public Lifelength GetFlightLifelengthIncludingThisFlight(BaseComponent baseComponent, AircraftFlight flight)
		{
			return _provider.GetFlightLifelengthIncludingThisFlightBaseComponent(baseComponent.ItemId, flight.ItemId);
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date)
		{
			return _provider.GetFlightLifelengthOnStartOfDayBaseComponent(baseComponent.ItemId, date);
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseComponent baseComponent, DateTime date, FlightRegime flightRegime)
		{
			return _provider.GetFlightLifelengthOnStartOfDayRegimeBaseComponent(baseComponent.ItemId, date, flightRegime.ItemId);
		}

		public Lifelength GetCurrentFlightLifelength(BaseComponent baseComponent)
		{
			return _provider.GetCurrentFlightLifelengthBaseComponent(baseComponent.ItemId);
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(BaseComponent baseComponent, DateTime effectiveDate)
		{
			return _provider.GetFlightLifelengthOnEndOfDayBaseComponent(baseComponent.ItemId, effectiveDate);
		}

		public Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate)
		{
			return _provider.GetFlightLifelengthForPeriodBaseComponent(baseComponent.ItemId, fromDate, toDate);
		}

		public Lifelength GetFlightLifelengthForPeriod(BaseComponent baseComponent, DateTime fromDate, DateTime toDate,
			FlightRegime flightRegime)
		{
			return _provider.GetFlightLifelengthForPeriodWithRegimeBaseComponent(baseComponent.ItemId, fromDate, toDate, flightRegime.ItemId);
		}

		public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd)
		{
			return _provider.GetFlightLifelengthBaseComponent(flight.ItemId, bd.ItemId);
		}

		public Lifelength GetFlightLifelength(AircraftFlight flight, BaseComponent bd, FlightRegime flightRegime)
		{
			return _provider.GetFlightLifelengthWithRegimeBaseComponent(flight.ItemId, bd.ItemId, flightRegime.ItemId);
		}

		public Lifelength GetCurrentFlightLifelength(Entities.General.Accessory.Component component)
		{
			return _provider.GetCurrentFlightLifelengthComponent(component.ItemId);
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(Entities.General.Accessory.Component component, DateTime effectiveDate)
		{
			return _provider.GetFlightLifelengthOnEndOfDayComponent(component.ItemId, effectiveDate);
		}

		public double GetTotalHours(AircraftFlightCollection flights)
		{
			throw new NotImplementedException();
		}

		public int GetTotalCycles(AircraftFlightCollection flights)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(DirectiveRecord record)
		{
			throw new NotImplementedException();
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(TransferRecord record)
		{
			throw new NotImplementedException();
		}

		public void CalculateLifeLimit(ComponentLLPCategoryData calculatedData, List<LLPLifeLimitCategory> categories, ComponentLLPDataCollection LLPData)
		{
			throw new NotImplementedException();
		}

		public bool IsEqual(double x, double y)
		{
			throw new NotImplementedException();
		}

		public void ResetMath(Aircraft aircraft)
		{
			throw new NotImplementedException();
		}

		public void ResetMath(BaseComponent baseComponent)
		{
			throw new NotImplementedException();
		}

		public void LoadCalculator()
		{
			throw new NotImplementedException();
		}
	}
}