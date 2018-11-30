using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IFlightFilterParams
	{
		[Filter("1 Monday", Order = 1)]
		bool IsMonday { get; }

		[Filter("2 Thursday", Order = 3)]
		bool IsThursday { get; }

		[Filter("3 Wednesday", Order = 5)]
		bool IsWednesday { get; }

		[Filter("4 Tuesday", Order = 7)]
		bool IsTuesday { get; }

		[Filter("5 Friday", Order = 9)]
		bool IsFriday { get; }

		[Filter("6 Saturday", Order = 11)]
		bool IsSaturday { get; }

		[Filter("7 Sunday", Order = 13)]
		bool IsSunday { get; }

		[Filter("Aircrafts")]
		CommonCollection<FlightNumberAircraftModelRelation> AircraftModels { get; }


		[Filter("FlightNo")]
		FlightNum FlightNo { get; }

		[Filter("AC Code")]
		FlightAircraftCode FlightAircraftCode { get; }

		[Filter("FL Type")]
		FlightType FlightType { get; }

		[Filter("FL Cat.")]
		FlightCategory FlightCategory { get; }

		[Filter("Departure")]
		AirportsCodes StationFrom { get; }

		[Filter("Arrival")]
		AirportsCodes StationTo { get; }

	}
}