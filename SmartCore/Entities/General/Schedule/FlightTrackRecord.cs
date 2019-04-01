using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General.Schedule
{
	[Table("FlightTripRecords", "dbo", "ItemId")]
	[Dto(typeof(FlightTrackRecordDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightTrackRecord : BaseEntityObject, ITripFilterParams
	{
		#region Fields

		private static Type _thisType;

			#endregion

		#region public int FlightTripId { get; set; }

		[TableColumn("FlightTripId")]
		public int FlightTripId { get; set; }

		public FlightTrack FlightTrack { get; set; }

		public static PropertyInfo FlightTripIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightTripId"); }
		}

		#endregion

		#region public int FlightPeriodId { get; set; }

		[TableColumn("FlightPeriodId")]
		public int FlightPeriodId { get; set; }
		public FlightNumberPeriod FlightNumberPeriod { get; set; }

		public static PropertyInfo FlightPeriodIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightPeriodId"); }
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(FlightTrackRecord));
		}
		#endregion

		#region Implement ITripFilterParams

		public TripName TripName { get { return FlightTrack.TripName ?? TripName.Unknown; } }
		public DayofWeek DayOfWeek { get { return FlightTrack.DayOfWeek; } }
		public FlightNum FlightNo { get { return FlightNumberPeriod.FlightNo; } }
		public AirportsCodes StationFrom { get { return FlightNumberPeriod.StationFrom; } }
		public AirportsCodes StationTo { get { return FlightNumberPeriod.StationTo; } }
		public FlightAircraftCode FlightAircraftCode { get { return FlightNumberPeriod.FlightAircraftCode; } }
		public FlightType FlightType { get { return FlightNumberPeriod.FlightType; } }
		public FlightCategory FlightCategory { get { return FlightNumberPeriod.FlightCategory; } }
		public Dictionaries.Schedule Schedule { get { return FlightNumberPeriod.Schedule; } }

		public string FlightTypeString { get { return FlightNumberPeriod.FlightType.RecoredType; } }

		#endregion

        public FlightTrackRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.FlightTrackRecord;
        }

	}
}