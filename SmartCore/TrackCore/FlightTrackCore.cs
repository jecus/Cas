using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.DtoHelper;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.NewLoader;
using SmartCore.Queries;

namespace SmartCore.TrackCore
{
	public class FlightTrackCore : IFlightTrackCore
	{
		private readonly INewLoader _newLoader;
		private readonly ILoader _loader;
		private readonly ICasEnvironment _environment;

		public FlightTrackCore(INewLoader newLoader, ILoader loader, ICasEnvironment environment)
		{
			_newLoader = newLoader;
			_loader = loader;
			_environment = environment;
		}

		#region public List<FlightTrackRecord> GetFlightTrackRecordsById(int itemId, bool loadChild = false)

		public List<FlightTrackRecord> GetFlightTrackRecordsByFlightTripId(int itemId, bool loadChild = false)
		{
			var tripRecords = _newLoader.GetObjectListAll<FlightTrackRecordDTO, FlightTrackRecord>(new Filter("FlightTripId", itemId), loadChild);

			if (loadChild)
			{
				if (tripRecords.Count > 0)
				{
					var periodsId = tripRecords.Select(t => t.FlightPeriodId).ToArray();
					var periods = _newLoader.GetObjectListAll<FlightNumberPeriodDTO, FlightNumberPeriod>(new Filter("ItemId", periodsId), getDeleted:true);

					if (periods.Count > 0)
					{
						var flightIds = periods.Select(p => p.FlightNumberId).ToArray();
						var flights = _newLoader.GetObjectListAll<FlightNumberDTO, FlightNumber>(new Filter("ItemId", flightIds), getDeleted: true);

						foreach (var period in periods)
							period.FlightNum = flights.FirstOrDefault(f => f.ItemId == period.FlightNumberId);
					}

					foreach (var trip in tripRecords)
						trip.FlightNumberPeriod = periods.FirstOrDefault(p => p.ItemId == trip.FlightPeriodId);
				}
			}

			return tripRecords.ToList();
		}

		#endregion

		#region public List<FlightTrackRecord> GetAllFlightTrackRecords(bool loadChild = false)

		public List<FlightTrackRecord> GetAllFlightTrackRecords(bool loadChild = false)
		{
			var tripRecords = _newLoader.GetObjectListAll<FlightTrackRecordDTO,FlightTrackRecord>(loadChild:loadChild).ToList();

			if (loadChild)
				loadChildTrackRecords(tripRecords);

			return tripRecords;
		}

		#endregion

		#region public List<FlightTrackRecord> GetAllFlightScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false)

		public List<FlightTrackRecord> GetAllFlightScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false)
		{
			var fl = _newLoader.GetObjectList<FlightNumberDTO, FlightNumber>(new Filter("FlightType", FlightType.Schedule.ItemId));
			var flNumberIds = fl.Select(i => i.ItemId);

			var query = BaseQueries.GetSelectQueryColumnOnly<FlightTrackRecord>(FlightTrackRecord.ItemIdProperty);
			query = $"{query} where FlightNumberId in ({string.Join(",", flNumberIds)}) " +
			        $"and (DepartureDate <= {from.ToSqlDate()} || DepartureDate <= {to.ToSqlDate()}) " +
			        $"and (ArrivalDate >= {from.ToSqlDate()}|| ArrivalDate >= {to.ToSqlDate()})";

			var res = _environment.Execute(query);
			var ids = new List<int>();
			foreach (DataRow row in res.Tables[0].Rows)
				ids.Add(Convert.ToInt32(row[0].ToString()));

			var tripRecords = _newLoader.GetObjectListAll<FlightTrackRecordDTO, FlightTrackRecord>(new Filter("FlightPeriodId", ids), loadChild).ToList();

			if (loadChild)
				loadChildTrackRecords(tripRecords);

			return tripRecords;
		}

		#endregion

		#region public List<FlightTrackRecord> GetAllFlightUnScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false)

		public List<FlightTrackRecord> GetAllFlightUnScheduleRecordsForPeriod(DateTime from, DateTime to, bool loadChild = false)
		{
			var flNumberIds = _newLoader.GetSelectColumnOnly<FlightNumberDTO>(new []{ new Filter("FlightType", FlightType.Schedule.ItemId) }, "ItemId");
			var flightNumberPeriodIds = _newLoader.GetSelectColumnOnly<FlightNumberPeriodDTO>(new List<Filter>()
			{
				new Filter("FlightNumberId",flNumberIds),
				new Filter("DepartureDate", FilterType.GratherOrEqual, from),
				new Filter("DepartureDate", FilterType.LessOrEqual, to)
			}, "ItemId");

			var tripRecords = _newLoader.GetObjectListAll<FlightTrackRecordDTO,FlightTrackRecord>(new Filter("FlightPeriodId", flightNumberPeriodIds), loadChild).ToList();

			if (loadChild)
				loadChildTrackRecords(tripRecords);

			return tripRecords;
		}

		#endregion

		#region public List<FlightTrackRecord> GetFlightTrackRecordsByItemIds(IEnumerable<int> ids, bool loadChild = false)

		public List<FlightTrackRecord> GetFlightTrackRecordsByItemIds(IEnumerable<int> ids, bool loadChild = false)
		{
			var tripRecords = _newLoader.GetObjectListAll<FlightTrackRecordDTO, FlightTrackRecord>(new Filter("ItemId", ids), loadChild).ToList();

			if (loadChild)
				loadChildTrackRecords(tripRecords);

			return tripRecords;
		}

		#endregion

		#region public List<FlightTrack> GetAllFlightTracks(bool loadChild = false)

		public List<FlightTrack> GetAllFlightTracks(bool loadChild = false)
		{
			var track = _newLoader.GetObjectListAll<FlightTrackDTO,FlightTrack>(loadChild: loadChild);
			if (loadChild)
			{
				var ids = track.SelectMany(t => t.FlightTripRecord.Select(f => f.FlightPeriodId)).ToArray();
				if (ids.Length > 0)
				{
					var periods = _newLoader.GetObjectListAll<FlightNumberPeriodDTO,FlightNumberPeriod>(new Filter("ItemId", ids), getDeleted: true);

					var flightids = periods.Select(p => p.FlightNumberId);
					var flights = _newLoader.GetObjectListAll<FlightNumberDTO, FlightNumber>(new Filter("ItemId", flightids), true,true);

					foreach (var flightNumberPeriod in periods)
						flightNumberPeriod.FlightNum = flights.FirstOrDefault(f => f.ItemId == flightNumberPeriod.FlightNumberId);

					foreach (var trip in track)
					{
						foreach (var record in trip.FlightTripRecord)
						{
							record.FlightTrack = trip;
							record.FlightNumberPeriod = periods.FirstOrDefault(p => p.ItemId == record.FlightPeriodId);
						}
					}
				}
			}

			return track.ToList();
		}

		#endregion

		#region private void loadChildTrackRecords(List<FlightTrackRecord> tripRecords)

		private void loadChildTrackRecords(List<FlightTrackRecord> tripRecords)
		{
			if (tripRecords.Count > 0)
			{
				var periodsId = tripRecords.Select(t => t.FlightPeriodId).ToArray();
				var periods = _newLoader.GetObjectListAll<FlightNumberPeriodDTO,FlightNumberPeriod>(new Filter("ItemId", periodsId), getDeleted: true);

				if (periods.Count > 0)
				{
					var flightIds = periods.Select(p => p.FlightNumberId).ToArray();
					var flights = _newLoader.GetObjectListAll<FlightNumberDTO,FlightNumber>(new Filter("ItemId", flightIds), getDeleted: true);

					foreach (var period in periods)
						period.FlightNum = flights.FirstOrDefault(f => f.ItemId == period.FlightNumberId);
				}

				var tripIds = tripRecords.Select(t => t.FlightTripId).ToArray();
				var trips = _newLoader.GetObjectListAll<FlightTrackDTO,FlightTrack>(new Filter("ItemId", tripIds), getDeleted: true);

				foreach (var trip in tripRecords)
				{
					trip.FlightNumberPeriod = periods.FirstOrDefault(p => p.ItemId == trip.FlightPeriodId);
					trip.FlightTrack = trips.FirstOrDefault(p => p.ItemId == trip.FlightTripId);
				}
			}
		}

		#endregion
	}
}