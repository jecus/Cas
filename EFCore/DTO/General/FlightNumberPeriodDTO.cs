using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberPeriodDTO : BaseEntity
	{
		[DataMember]
		public int FlightNumberId { get; set; }

		[DataMember]
		public int? PeriodFrom { get; set; }

		[DataMember]
		public int? PeriodTo { get; set; }

		[DataMember]
		public bool? IsMonday { get; set; }

		[DataMember]
		public bool? IsThursday { get; set; }

		[DataMember]
		public bool? IsWednesday { get; set; }

		[DataMember]
		public bool? IsTuesday { get; set; }

		[DataMember]
		public bool? IsFriday { get; set; }

		[DataMember]
		public bool? IsSaturday { get; set; }

		[DataMember]
		public bool? IsSunday { get; set; }

		[DataMember]
		public DateTime? DepartureDate { get; set; }

		[DataMember]
		public DateTime? ArrivalDate { get; set; }

		[DataMember]
		public int Schedule { get; set; }
	}
}