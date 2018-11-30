using System;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IFlightNumberParams : IBaseEntityObject
	{
		FlightNumber FlightNum { get; }
		int PeriodFrom { get; }
		int PeriodTo { get; }
		DateTime ArrivalDate { get;}
		DateTime DepartureDate { get;}
	}
}