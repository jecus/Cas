using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("FlightNumberPeriods", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightNumberPeriodDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightNumberId")]
		public int FlightNumberId { get; set; }

		[DataMember]
		[Column("PeriodFrom")]
		public int? PeriodFrom { get; set; }

		[DataMember]
		[Column("PeriodTo")]
		public int? PeriodTo { get; set; }

		[DataMember]
		[Column("IsMonday")]
		public bool? IsMonday { get; set; }

		[DataMember]
		[Column("IsThursday")]
		public bool? IsThursday { get; set; }

		[DataMember]
		[Column("IsWednesday")]
		public bool? IsWednesday { get; set; }

		[DataMember]
		[Column("IsTuesday")]
		public bool? IsTuesday { get; set; }

		[DataMember]
		[Column("IsFriday")]
		public bool? IsFriday { get; set; }

		[DataMember]
		[Column("IsSaturday")]
		public bool? IsSaturday { get; set; }

		[DataMember]
		[Column("IsSunday")]
		public bool? IsSunday { get; set; }

		[DataMember]
		[Column("DepartureDate")]
		public DateTime? DepartureDate { get; set; }

		[DataMember]
		[Column("ArrivalDate")]
		public DateTime? ArrivalDate { get; set; }

		[DataMember]
		[Column("Schedule"), Required]
		public int Schedule { get; set; }
	}
}