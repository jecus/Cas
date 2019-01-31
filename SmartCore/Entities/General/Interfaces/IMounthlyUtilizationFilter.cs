using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IMounthlyUtilizationFilter
	{
		[Filter("ATLB:", Order = 1)]
		string ATLB { get; }

		[Filter("Flight No:", Order = 2)]
		string FlightN { get; }

		[Filter("Station From:", Order = 3)]
		AirportsCodes StationFromId { get; }

		[Filter("Station To:", Order = 4)]
		AirportsCodes StationToId { get; }
	}
}