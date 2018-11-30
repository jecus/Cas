using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using EFCore.Filter;
using SmartCore.Aircrafts;
using SmartCore.Auxiliary;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.NewLoader;
using SmartCore.Filters;
using SmartCore.TrackCore;
using FilterType = EFCore.Attributte.FilterType;

namespace SmartCore.Calculations.PlanOpsCalculator
{
	public class PlanOpsCalculator : IPlanOpsCalculator
	{
		private readonly INewLoader _newLoader;
		private readonly INewKeeper _newKeeper;
		private readonly IAircraftsCore _aircraftsCore;
		private readonly IFlightTrackCore _flightTrackCore;

		#region public PlanOpsCalculator(ILoader loader, IKeeper keeper, IAircraftsCore aircraftsCore ,IFlightTrackCore flightTrackCore)

		public PlanOpsCalculator(INewLoader newLoader, INewKeeper newKeeper, IAircraftsCore aircraftsCore ,IFlightTrackCore flightTrackCore)
		{
			_newLoader = newLoader;
			_newKeeper = newKeeper;
			_aircraftsCore = aircraftsCore;
			_flightTrackCore = flightTrackCore;
		}

		#endregion

		#region public List<FlightPlanOpsRecords> CalculateTripForPeriod(FlightPlanOps currentPlanOps)

		public List<FlightPlanOpsRecords> CalculateTripForPeriod(FlightPlanOps currentPlanOps)
		{
			var preResult = new List<FlightPlanOpsRecords>();

			var calculatedDates = DateTimeExtend.AllDatesBetween(currentPlanOps.From, currentPlanOps.To).ToList();
			var flightTrackRecords = _flightTrackCore.GetAllFlightScheduleRecordsForPeriod(currentPlanOps.From, currentPlanOps.To, true);
			flightTrackRecords.AddRange(_flightTrackCore.GetAllFlightUnScheduleRecordsForPeriod(currentPlanOps.From, currentPlanOps.To, true));

			foreach (var record in flightTrackRecords)
			{
				var date = getDateFromDayofWeek(record.FlightTrack.DayOfWeek, calculatedDates);
				if (date < DateTimeExtend.GetCASMinDateTime())
					continue;

				if (record.FlightType == FlightType.Schedule && !(date >= record.FlightNumberPeriod.DepartureDate.Date && date <= record.FlightNumberPeriod.ArrivalDate.Date))
					continue;
				var newOps = new FlightPlanOpsRecords
				{
					Date = date.Value,
					FlightTrackRecord = record,
					FlightTrackRecordId = record.ItemId,
					ParentFlightPlanOps = currentPlanOps,
					PeriodFrom = record.FlightNumberPeriod.PeriodFrom,
					PeriodTo = record.FlightNumberPeriod.PeriodTo
				};

				preResult.Add(newOps);
			}

			return preResult;
		}

		#endregion

		#region public List<FlightPlanOpsRecords> LoadOpsRecordsByPlanOpsId(int planOpsId)

		public List<FlightPlanOpsRecords> LoadOpsRecordsByPlanOpsId(int planOpsId)
		{
			return loadOpsRecordsByPlanOpsId(planOpsId);
		}

		#endregion

		public List<FlightPlanOpsRecords> LoadAircraftStatusOps()
		{
			var records = new List<FlightPlanOpsRecords>();

			var aircrafts = _aircraftsCore.GetAllAircrafts();
			foreach (var aircraft in aircrafts)
			{
				var find = new List<FlightPlanOpsRecords>();

				find.AddRange(_newLoader.GetObjectList<FlightPlanOpsRecordsDTO, FlightPlanOpsRecords>(new List<Filter>()
				{
					new Filter("AircraftId",aircraft.ItemId ),
					new Filter("ParentFlightId", FilterType.Grather, 0)
				}));
				find.AddRange(_newLoader.GetObjectList<FlightPlanOpsRecordsDTO, FlightPlanOpsRecords>(new List<Filter>()
				{
					new Filter("AircraftExchangeId",aircraft.ItemId ),
					new Filter("ParentFlightId", FilterType.Grather, 0)
				}));

				var record = find.OrderByDescending(i => i.Date).FirstOrDefault();

				if (record == null)
					continue;

				records.Add(record);
			}

			loadChild(records);

			return records;
		}

		#region public void CreateCopeFromExistPlan(FlightPlanOps currentPlanOps)

		public void CreateCopyFromExistPlan(FlightPlanOps currentPlanOps)
		{
			var records = loadOpsRecordsByPlanOpsId(currentPlanOps.ItemId);

			var copyPlanOps = currentPlanOps.GetCopyUnsaved();
			_newKeeper.Save(copyPlanOps);

			var newRecords = CalculateTripForPeriod(copyPlanOps);

			foreach (var newRecord in newRecords)
			{
				var track = records.FirstOrDefault(i => i.FlightTrackRecordId == newRecord.FlightTrackRecordId);
				if (track != null)
				{
					newRecord.AircraftId = track.AircraftId;
					newRecord.AircraftExchangeId = track.AircraftExchangeId;
				}
				_newKeeper.Save(newRecord);
			}
		}

		#endregion

		#region private List<FlightPlanOpsRecords> loadOpsRecordsByPlanOpsId(int planOpsId)

		private List<FlightPlanOpsRecords> loadOpsRecordsByPlanOpsId(int planOpsId)
		{
			var records = _newLoader.GetObjectListAll<FlightPlanOpsRecordsDTO, FlightPlanOpsRecords>(new Filter("FlightPlanOpsId", planOpsId), true);

			loadChild(records);

			return records.ToList();
		}

		#endregion

		#region private void loadChild(IList<FlightPlanOpsRecords> records)

		private void loadChild(ICollection<FlightPlanOpsRecords> records)
		{
			if (records.Count == 0)
				return;

			var ids = records.Select(i => i.FlightTrackRecordId);
			var trackRecords = _flightTrackCore.GetFlightTrackRecordsByItemIds(ids, true);

			var flightIds = records.Select(i => i.ParentFlightId);
			var flights = _newLoader.GetObjectListAll<AircraftFlightDTO, AircraftFlight>(new Filter("ItemId", flightIds));

			foreach (var record in records)
			{
				record.FlightTrackRecord = trackRecords.FirstOrDefault(i => i.ItemId == record.FlightTrackRecordId);
				record.ParentFlight = flights.FirstOrDefault(i => i.ItemId == record.ParentFlightId);
				record.Aircraft = _aircraftsCore.GetAircraftById(record.AircraftId);
				record.AircraftExchange = _aircraftsCore.GetAircraftById(record.AircraftExchangeId);
			}
		}

		#endregion

		#region private DateTime? getDateFromDayofWeek(DayofWeek dayOfWeek, List<DateTime> listDates)

		private DateTime? getDateFromDayofWeek(DayofWeek dayOfWeek, List<DateTime> listDates)
		{
			DayOfWeek day;
			if (dayOfWeek == DayofWeek.Monday)
				day = DayOfWeek.Monday;
			else if (dayOfWeek == DayofWeek.Tuesday)
				day = DayOfWeek.Tuesday;
			else if (dayOfWeek == DayofWeek.Wednesday)
				day = DayOfWeek.Wednesday;
			else if (dayOfWeek == DayofWeek.Thursday)
				day = DayOfWeek.Thursday;
			else if (dayOfWeek == DayofWeek.Friday)
				day = DayOfWeek.Friday;
			else if (dayOfWeek == DayofWeek.Saturday)
				day = DayOfWeek.Saturday;
			else
				day = DayOfWeek.Sunday;

			return listDates.FirstOrDefault(d => d.DayOfWeek.Equals(day));
		}

		#endregion
	}
}