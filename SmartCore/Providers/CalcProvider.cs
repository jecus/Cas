using System;
using System.Collections.Generic;
using System.Net.Http;
using CAS.UI.Helpers;
using EntityCore.Filter;
using SmartCore.Calculations;

namespace SmartCore.Providers
{
	public class CalcProvider
	{
		private HttpClient _httpClient;

		public CalcProvider(string serverName)
		{
			_httpClient = new HttpClient() { BaseAddress = new Uri(serverName) };
		}

		#region Component
		
		public Lifelength GetCurrentFlightLifelengthComponent(int componentId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength> (HttpMethod.Post, $"component/current", new { ComponentId = componentId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnEndOfDayComponent(int componentId, DateTime effectiveDate)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"component/onendofday", new { ComponentId = componentId, EffectiveDate = effectiveDate });
			return res?.Data ?? Lifelength.Null;
		}

		#endregion

		#region Calculator

		public Lifelength GetFlightLifelengthForPeriodCalculator(int aircraftId, DateTime dateFrom, DateTime dateTo)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"calculator/forperiod", new { AircraftId = aircraftId, DateFrom = dateFrom, DateTo = dateTo });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnStartOfDayCalculator(int aircraftId, DateTime currentDate)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"calculator/onstartofday", new { AircraftId = aircraftId, CurrentDate = currentDate });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnEndOfDayCalculator(int aircraftId, DateTime currentDate)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"calculator/onendofday", new { AircraftId = aircraftId, CurrentDate = currentDate });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthIncludingThisFlightCalculator(int flightId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"calculator/includingthisflight", new { FlightId = flightId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetCurrentFlightLifelengthCalculator(int aircraftId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"calculator/currentflight", new { AircraftId = aircraftId });
			return res?.Data ?? Lifelength.Null;
		}

		#endregion

		#region BaseComponent

		public Lifelength GetFlightLifelengthIncludingThisFlightBaseComponent(int baseComponentId, int flightId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/includingthisflight", new { BaseComponentId = baseComponentId, FlightId = flightId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnStartOfDayBaseComponent(int baseComponentId, DateTime date)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/onstartofday", new { BaseComponentId = baseComponentId, Date = date });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnStartOfDayRegimeBaseComponent(int baseComponentId, DateTime date, int flightRegimeId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/onstartofdayregime", new { BaseComponentId = baseComponentId, Date = date, FlightRegimeId = flightRegimeId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetCurrentFlightLifelengthBaseComponent(int baseComponentId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/currentflight", new { BaseComponentId = baseComponentId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthOnEndOfDayBaseComponent(int baseComponentId, DateTime effectiveDate)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/onendofday", new { BaseComponentId = baseComponentId, EffectiveDate = effectiveDate });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthForPeriodBaseComponent(int baseComponentId, DateTime fromDate, DateTime toDate)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/forperiod", new { BaseComponentId = baseComponentId, FromDate = fromDate, ToDate = toDate });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthForPeriodWithRegimeBaseComponent(int baseComponentId, DateTime fromDate, DateTime toDate, int flightRegimeId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/forperiodwithregime", new { BaseComponentId = baseComponentId, FromDate = fromDate, ToDate = toDate, FlightRegimeId = flightRegimeId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthBaseComponent(int flightId, int baseComponentId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/flight", new { FlightId = flightId, BaseComponentId = baseComponentId });
			return res?.Data ?? Lifelength.Null;
		}

		public Lifelength GetFlightLifelengthWithRegimeBaseComponent(int flightId, int baseComponentId, int flightRegimeId)
		{
			var res = _httpClient.SendJsonAsync<object, Lifelength>(HttpMethod.Post, $"basecomponent/withregime", new { FlightId = flightId, BaseComponentId = baseComponentId, FlightRegimeId = flightRegimeId });
			return res?.Data ?? Lifelength.Null;
		}

		#endregion
	}
}