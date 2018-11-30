using System;
using EFCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Schedule
{
	[Table("FlightTrips", "dbo", "ItemId")]
	[Dto(typeof(FlightTrackDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class FlightTrack : BaseEntityObject
	{
		#region public TripName TripName { get; set; }

		[TableColumn("TripName")]
		public TripName TripName { get; set; }

		#endregion

		#region public string Remarks { get; set; }

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		#endregion

		#region public DayofWeek DayOfWeek { get; set; }

		[TableColumn("DayOfWeek")]
		public DayofWeek DayOfWeek
		{
			get { return _dayOfWeek ?? DayofWeek.Unknown; }
			set { _dayOfWeek = value; }
		}

		#endregion

		#region public CommonCollection<FlightTripRecord> FlightNumberPeriod { get; set; }

		private CommonCollection<FlightTrackRecord> _flightNumberPeriod;
		private DayofWeek _dayOfWeek;

		/// <summary>
		/// Состав экипажа на рейс
		/// </summary>
		[Child(RelationType.OneToMany, "FlightTripId", "FlightTripRecord")]
		public CommonCollection<FlightTrackRecord> FlightTripRecord
		{
			get { return _flightNumberPeriod ?? (_flightNumberPeriod = new CommonCollection<FlightTrackRecord>()); }
			set
			{
				if (_flightNumberPeriod != value)
				{
					if (_flightNumberPeriod != null)
						_flightNumberPeriod.Clear();
					if (value != null)
						_flightNumberPeriod = value;
				}
			}
		}


		#endregion

		#region public Supplier Supplier { get; set; }

		private Supplier _supplier;
		[TableColumn("SupplierID")]
		[Child]
		public Supplier Supplier
		{
			get { return _supplier ?? Supplier.Unknown; }
			set { _supplier = value; }
		}

		#endregion

		#region public override string ToString()

		public override string ToString()
		{
			var str = $"{TripName.FullName} {DayOfWeek}";

			foreach (var record in FlightTripRecord)
			{
				if (record.FlightNo != null)
					str += $" {record.FlightNo},";
			}

			return str;
		}

		#endregion
	}
}