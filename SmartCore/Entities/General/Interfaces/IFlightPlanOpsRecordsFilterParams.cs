using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IFlightPlanOpsRecordsFilterParams
	{
		[Filter("Aircraft", Order = 1)]
		Aircraft Aircraft { get; set; }

		[Filter("DayOfWeek", Order = 2)]
		DayofWeek DayOfWeek { get; }

		[Filter("Arrival", Order = 5)]
		AirportsCodes StationTo { get; }

		[Filter("Departure", Order = 3)]
		AirportsCodes StationFrom { get; }

		[Filter("FlightNo", Order = 4)]
		FlightNum FlightNo { get; }

		[Filter("FlightTrack", Order = 7)]
		FlightTrack FlightTrack { get;}

		[Filter("FL Type", Order = 6)]
		FlightType FlightType { get; }

		[Filter("Schedule", Order = 8)]
		Dictionaries.Schedule Schedule { get; }

		[Filter("FL Cat.", Order = 9)]
		FlightCategory FlightCategory { get; }

	}
}