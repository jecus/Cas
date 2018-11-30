using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface ITripFilterParams
	{
		[Filter("TripName", Order = 1)]
		TripName TripName { get; }

		[Filter("DayOfWeek", Order = 2)]
		DayofWeek DayOfWeek { get; }

		[Filter("FlightNo", Order = 3)]
		FlightNum FlightNo { get; }

		[Filter("Departure", Order = 4)]
		AirportsCodes StationFrom { get; }

		[Filter("Arrival", Order = 5)]
		AirportsCodes StationTo { get; }

		[Filter("AC Code", Order = 6)]
		FlightAircraftCode FlightAircraftCode { get; }

		[Filter("FL Type", Order = 7)]
		FlightType FlightType { get; }

		[Filter("FL Cat.", Order = 8)]
		FlightCategory FlightCategory { get; }

		[Filter("Schedule", Order = 9)]
		Dictionaries.Schedule Schedule { get; }
	}
}