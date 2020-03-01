using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using SmartCore.Analyst;
using SmartCore.Auxiliary;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Providers;
using Convert = System.Convert;

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
			//TODO: так как вынесл в отдельный сервис все это не нужно(в перспективе убрать метод)
		}

		public void InitAsync(BackgroundWorker backgroundWorker, LoadingState loadingState)
		{
			//TODO: так как вынесл в отдельный сервис все это не нужно(в перспективе убрать метод) но как все взлетит надо убедиться что он не нужен
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
			if (source == null) return Lifelength.Null;
			if (forecastData == null) return GetFlightLifelengthOnEndOfDay(source, DateTime.Today);
			if (forecastData.ForecastDate <= DateTime.Today) return GetFlightLifelengthOnEndOfDay(source, forecastData.ForecastDate);

			var res = GetFlightLifelengthOnEndOfDay(source, DateTime.Today);
			res += AnalystHelper.GetUtilization(forecastData.AverageUtilization, (forecastData.ForecastDate - DateTime.Today).Days);
			return res;
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(BaseEntityObject source, DateTime effDate)
		{
			if (source is Operator || source == null)
			{
				if (effDate.Date <= DateTimeExtend.GetCASMinDateTime()) return Lifelength.Zero;
				// вычисляем результат
				var res = new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), effDate.Date) };
				return res;
			}
			if (source is Aircraft) return GetFlightLifelengthOnEndOfDay((Aircraft)source, effDate);
			if (source is BaseComponent) return GetFlightLifelengthOnEndOfDay((BaseComponent)source, effDate);
			if (source is Entities.General.Accessory.Component) return GetFlightLifelengthOnEndOfDay((Entities.General.Accessory.Component)source, effDate);
			return Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, DateTime effDate)
		{
			if (source == null) return Lifelength.Null;
			if (source is Operator)
			{
				if (effDate.Date <= DateTimeExtend.GetCASMinDateTime()) return Lifelength.Zero;
				// вычисляем результат
				var res = new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), effDate.Date) };
				return res;
			}
			if (source is Aircraft) return GetFlightLifelengthOnStartOfDay((Aircraft)source, effDate);
			if (source is BaseComponent) return GetFlightLifelengthOnStartOfDay((BaseComponent)source, effDate);
			//TODO:(Evgenii Babak) выяснить почему берется наработка на конец дня и не делается cast к Component
			if (source is Entities.General.Accessory.Component) return GetFlightLifelengthOnEndOfDay(source, effDate);
			return Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnStartOfDay(BaseEntityObject source, ForecastData forecastData = null)
		{
			if (source == null)
				return new Lifelength { Days = GetDays(DateTimeExtend.GetCASMinDateTime(), DateTime.Today) };

			if (forecastData == null) return GetFlightLifelengthOnStartOfDay(source, DateTime.Today);
			if (forecastData.ForecastDate <= DateTime.Today) return GetFlightLifelengthOnStartOfDay(source, forecastData.ForecastDate);

			var res = GetFlightLifelengthOnStartOfDay(source, DateTime.Today);
			res += AnalystHelper.GetUtilization(forecastData.AverageUtilization, (forecastData.ForecastDate - DateTime.Today).Days);
			return res;
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
			return flights.Where(ItWasRealFlight)
				.Sum(aircraftFlight => aircraftFlight.FlightTime.TotalHours);
		}

		public int GetTotalCycles(AircraftFlightCollection flights)
		{
			return (int)flights.Where(ItWasRealFlight)
				.Sum(aircraftFlight => aircraftFlight.FlightTimeLifelength.Cycles);
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(DirectiveRecord record)
		{
			object parent = record.Parent;
			if (parent == null) throw new Exception($"1537: Performance record {record.RecordType} ({record.ItemId}:{record.ParentId}) referst to null object");

			//
			var date = record.RecordDate;

			// Обрабатываем объекты
			if (parent is ComponentDirective componentDirective)
			{
				// Запись принадлежит работе по агрегату
				// Агрегат / Базовый агрегат
				if (componentDirective.ParentComponent.IsBaseComponent) return GetFlightLifelengthOnEndOfDay((BaseComponent)componentDirective.ParentComponent, date);
				if (!componentDirective.ParentComponent.IsBaseComponent) return GetFlightLifelengthOnEndOfDay(componentDirective.ParentComponent, date);
				throw new Exception($"1543: Can not get parent object for component directive {componentDirective.ItemId}");
			}
			if (parent is Directive directive1)
			{
				var bd = directive1.ParentBaseComponent;
				if (bd == null) throw new Exception($"1550: Parent object for directive {directive1.ItemId} is set to null");
				return GetFlightLifelengthOnEndOfDay(bd, date);
			}
			if (parent is MaintenanceDirective directive)
			{
				var a = directive.ParentBaseComponent;
				if (a == null) throw new Exception($"1550: Parent object for directive {directive.ItemId} is set to null");
				return GetFlightLifelengthOnEndOfDay(a, date);
			}
			if (parent is Procedure p)
			{
				var op = p.ParentOperator;
				if (op == null) throw new Exception($"1550: Parent object for directive {p.ItemId} is set to null");
				return GetFlightLifelengthOnEndOfDay(op, date);
			}
			throw new Exception($"1545: Can not recognize parent object {parent.GetType()} for record {record.RecordType} ({record.ItemId}:{record.ParentId})");
		}

		public Lifelength GetFlightLifelengthOnEndOfDay(TransferRecord record)
		{
			if (record.ParentComponent != null)
			{
				return record.ParentComponent is BaseComponent 
					? GetFlightLifelengthOnEndOfDay((BaseComponent)record.ParentComponent, record.TransferDate)
					: GetFlightLifelengthOnEndOfDay(record.ParentComponent, record.TransferDate);
			}
			throw new Exception($"Transfer record {record.ItemId} for {record.ParentId} has no parent");
		}

		public void CalculateLifeLimit(ComponentLLPCategoryData calculatedData, List<LLPLifeLimitCategory> categories, ComponentLLPDataCollection LLPData)
		{
			double aCycle = 0, bCycle = 0, cCycle = 0, dCycle;

			foreach (var category in categories)
			{
				var data = LLPData.GetItemByCatagory(category);

				//TODO:Заплатка
				if (data?.LLPCurrent == null)
					data.LLPCurrent = data.LLPLifelengthCurrent ?? data.LLPLifeLengthForDate;

				if (data?.LLPCurrent == null || data.LLPLifeLimit == null)
					continue;
				double currentCycle = data.LLPCurrent.Cycles.GetValueOrDefault();
				double limitCycle = data.LLPLifeLimit.Cycles.GetValueOrDefault();
				var resultCycle = currentCycle / limitCycle;

				if (category.CategoryType == LLPLifeLimitCategoryType.A)
				{
					aCycle = !double.IsNaN(resultCycle) ? Math.Round(resultCycle, 5) : 0;
					continue;
				}
				if (category.CategoryType == LLPLifeLimitCategoryType.B)
				{
					bCycle = !double.IsNaN(resultCycle) ? Math.Round(resultCycle, 5) : 0;
					continue;
				}
				if (category.CategoryType == LLPLifeLimitCategoryType.C)
				{
					cCycle = !double.IsNaN(resultCycle) ? Math.Round(resultCycle, 5) : 0;
					continue;
				}

				dCycle = !double.IsNaN(resultCycle) ? Math.Round(resultCycle, 5) : 0;

				double resCycle = 1F;

				if (aCycle != 0)
					resCycle -= aCycle;
				if (bCycle != 0)
					resCycle -= bCycle;
				if (cCycle != 0)
					resCycle -= cCycle;
				if (dCycle != 0)
					resCycle -= dCycle;

				//if(!double.IsNaN(resultCycle))
				if (calculatedData.Remain != null && calculatedData.LLPLifeLimit?.Cycles != null)
					calculatedData.Remain.Cycles = (int)(resCycle * calculatedData.LLPLifeLimit.Cycles.GetValueOrDefault());
			}
		}

		public bool IsEqual(double x, double y)
		{
			var eps = 0.0001;
			return Math.Abs(x - y) < eps;
		}

		public void ResetMath(Aircraft aircraft)
		{
			//TODO: заюзать метод в CalculatorController
		}

		public void ResetMath(BaseComponent baseComponent)
		{
			//TODO: заюзать метод в BaseComponentController
		}

		public void LoadCalculator()
		{
			//TODO: так как вынесл в отдельный сервис все это не нужно(в перспективе убрать метод)
		}

		#region public static Int32 GetDays(DateTime dateFrom, DateTime dateTo)
		/// <summary>
		/// Возвращает количество дней между двумя датами 
		/// </summary>
		/// <param name="dateFrom"></param>
		/// <param name="dateTo"></param>
		/// <returns></returns>
		public static int GetDays(DateTime dateFrom, DateTime dateTo)
		{
			return Convert.ToInt32((dateTo.Date.Ticks - dateFrom.Date.Ticks) / TimeSpan.TicksPerDay);
		}
		#endregion

		#region Helpers

		private bool ItWasRealFlight(AircraftFlight flight)
		{
			return flight.AtlbRecordType == AtlbRecordType.Flight && flight.CancelReason == null;
		}

		#endregion
	}
}