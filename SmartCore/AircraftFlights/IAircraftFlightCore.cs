using System;
using System.Collections.Generic;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.AircraftFlights
{
	public interface IAircraftFlightCore
	{
		AircraftFlight LoadFullAircraftFlightById(int flightId, int parentAircraftId);

		void GetAircraftInformationToFlight(int parentAircraftId, AircraftFlight flight);

		void AddAircraftFlight(AircraftFlight flight);

		void Delete(AircraftFlight aircraftFlight);

		void AddReason(Reason reason);

		void Save(FlightNumber saveObject);

		void LoadAllFlights();

		void LoadAircraftFlights(int aircraftId);

		void LoadAircraftFlightsLight(int aircraftId);

		AircraftFlightCollection GetAircraftFlightsByAircraftId(int aircraftId);

		AircraftFlight GetFirstFlight(int atlbId);

		AircraftFlight GetLastFlight(int atlbId);

		AircraftFlight GetAircraftFlightById(int aircraftId, int aircraftFlightId);

		AircraftFlight GetLastAircraftFlight(int aircraftId);

		IEnumerable<AircraftFlight> GetAircraftFlightsOnDate(int aircraftId, DateTime flightDate);

		AircraftFlightCollection GetFlightsByAtlb(params object[] parametres);

		List<AircraftFlight> GetFlightWithPageNum(int aircraftId, string pageNum, int atlbId);
		IList<ATLB> GetATLBsByAircraftId(int aircraftId, bool loadChild = false, bool onlyOpened = false);

		FlightNumber GetFlightNumberById(int itemId, bool loadChild);

		List<FlightNumber> GetAllFlightNumbers();

		string GetLastPageNoFromAtlb(int atlbId, int aircraftId);

		string GetNextPageNoFromAtlb(int atlbId, int aircraftId);
	}
}