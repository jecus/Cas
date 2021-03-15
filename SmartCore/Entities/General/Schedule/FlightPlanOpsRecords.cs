using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Schedule
{
	[Table("FlightPlanOpsRecords", "dbo", "ItemId")]
	[Dto(typeof(FlightPlanOpsRecordsDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightPlanOpsRecords : BaseEntityObject, IFlightPlanOpsRecordsFilterParams
	{
		private static Type _thisType;

		#region public FlightPlanOps ParentFlightPlanOps { get; set; }

		[TableColumn("FlightPlanOpsId")]
		[Child]
		public FlightPlanOps ParentFlightPlanOps { get; set; }

		public static PropertyInfo ParentFlightPlanOpsProperty
		{
			get { return GetCurrentType().GetProperty("ParentFlightPlanOps"); }
		}

		#endregion

		#region public DateTime Date { get; set; }

		[TableColumn("PlanDate")]
		public DateTime Date { get; set; }

		#endregion

		#region public Aircraft Aircraft { get; set; }

		[TableColumn("AircraftId")]
		public int AircraftId { get; set; }

		public Aircraft Aircraft { get; set; }

		#endregion

		#region public Aircraft AircraftExchange { get; set; }

		[TableColumn("AircraftExchangeId")]
		public int AircraftExchangeId { get; set; }
		public Aircraft AircraftExchange { get; set; }

		#endregion

		#region public Aircraft CurrentAircraft

		public Aircraft CurrentAircraft
		{
			get { return AircraftExchange ?? Aircraft; }
		}

		#endregion

		#region public OpsStatus Status { get; set; }
		
		private OpsStatus _status;

		[TableColumn("StatusId")]
		public OpsStatus Status
		{
			get { return _status ?? OpsStatus.Unknown; }
			set { _status = value; }
		}

			#endregion

		#region public Reason DelayReason { get; set; }

		[TableColumn("DelayReasonId")]
		public Reason DelayReason { get; set; }

		#endregion

		#region public Reason DelayReason { get; set; }

		[TableColumn("ReasonId")]
		public Reason Reason { get; set; }

		#endregion

		#region public Reason CancelReason { get; set; }

		[TableColumn("CancelReasonId")]
		public Reason CancelReason { get; set; }

		#endregion

		#region public FlightTrackRecord FlightTrackRecord { get; set; }

		[TableColumn("FlightTrackRecordId")]
		public int FlightTrackRecordId { get; set; }

		public FlightTrackRecord FlightTrackRecord { get; set; }

		#endregion

		#region public bool IsDispatcherEdit { get; set; }

		[TableColumn("IsDispatcherEdit")]
		public bool IsDispatcherEdit { get; set; }

		#endregion

		#region public bool IsDispatcherEditLdg { get; set; }

		[TableColumn("IsDispatcherEditLdg")]
		public bool IsDispatcherEditLdg { get; set; }

		#endregion
		

		#region public int PeriodFrom { get; set; }

		[TableColumn("PeriodFrom")]
		public int PeriodFrom { get; set; }

		#endregion

		#region public int PeriodTo { get; set; }

		[TableColumn("PeriodTo")]
		public int PeriodTo { get; set; }

		#endregion

		#region public int ParentFlightId { get; set; }

		[TableColumn("ParentFlightId")]
		public int ParentFlightId { get; set; }

		public AircraftFlight ParentFlight { get; set; }

		#endregion

		#region public string Remarks { get; set; }

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		#endregion

		#region public string HiddenRemarks { get; set; }

		[TableColumn("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		#endregion

		#region public Document ReasonDocument { get; set; }

		public Document ReasonDocument { get; set; }

		#endregion

		#region public Document DelayDocument { get; set; }

		public Document DelayDocument { get; set; }

		#endregion

		#region public Document CancellationDocument { get; set; }

		public Document CancellationDocument { get; set; }

		#endregion


		#region #IFlightPlanOpsRecordsFilterParams

		public AirportsCodes StationFrom { get { return FlightTrackRecord.StationFrom; } }
		public AirportsCodes StationTo { get { return FlightTrackRecord.StationTo; } }
		public FlightNum FlightNo { get { return FlightTrackRecord.FlightNo; } }
		public FlightTrack FlightTrack { get { return FlightTrackRecord.FlightTrack; } }
		public FlightType FlightType { get { return FlightTrackRecord.FlightType; } }
		public FlightCategory FlightCategory { get { return FlightTrackRecord.FlightCategory; } }
		public Dictionaries.Schedule Schedule { get { return FlightTrackRecord.Schedule; } }

		public DayofWeek DayOfWeek { get { return FlightTrack.DayOfWeek; } }

		#endregion


		#region public FlightPlanOpsRecords()

		public FlightPlanOpsRecords()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.FlightPlanOpsRecords;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(FlightPlanOpsRecords));
		}
		#endregion


		#region public new FlightPlanOpsRecords GetCopyUnsaved()

		public new FlightPlanOpsRecords GetCopyUnsaved(bool marked = true)
		{
			var newFlightPlanOpsRecords = (FlightPlanOpsRecords) MemberwiseClone();
			newFlightPlanOpsRecords.ItemId = -1;
			newFlightPlanOpsRecords.ParentFlightId = -1;
			newFlightPlanOpsRecords.UnSetEvents();

			return newFlightPlanOpsRecords;
		}

		#endregion

	}
}