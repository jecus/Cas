using System;
using System.Collections.Generic;
using SmartCore.Entities.General.Schedule;

namespace SmartCore.TrackCore
{
	public interface IFlightTrackCore
	{
		List<FlightTrackRecord> GetFlightTrackRecordsByFlightTripId(int itemId, bool loadChild = false);
		List<FlightTrackRecord> GetAllFlightTrackRecords(bool loadChild = false);
		List<FlightTrackRecord> GetAllFlightScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false);
		List<FlightTrackRecord> GetAllFlightUnScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false);
		List<FlightTrackRecord> GetFlightTrackRecordsByItemIds(IEnumerable<int> ids, bool loadChild = false);
		List<FlightTrack> GetAllFlightTracks(bool loadChild = false);
		
	}
}