using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("FlightPlanOpsRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsRecordsDTO : BaseEntity
	{
		[DataMember]
		[Column("FlightPlanOpsId")]
		public int? FlightPlanOpsId { get; set; }

		[DataMember]
		[Column("AircraftId")]
		public int? AircraftId { get; set; }

		[DataMember]
		[Column("AircraftExchangeId")]
		public int? AircraftExchangeId { get; set; }

		[DataMember]
		[Column("DelayReasonId")]
		public int? DelayReasonId { get; set; }

		[DataMember]
		[Column("CancelReasonId")]
		public int? CancelReasonId { get; set; }

		[DataMember]
		[Column("ReasonId")]
		public int? ReasonId { get; set; }

		[DataMember]
		[Column("FlightTrackRecordId")]
		public int? FlightTrackRecordId { get; set; }

		[DataMember]
		[Column("PeriodFrom")]
		public int? PeriodFrom { get; set; }

		[DataMember]
		[Column("PeriodTo")]
		public int? PeriodTo { get; set; }

		[DataMember]
		[Column("PlanDate")]
		public DateTime? PlanDate { get; set; }

		[DataMember]
		[Column("ParentFlightId")]
		public int? ParentFlightId { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("IsDispatcherEdit")]
		public bool? IsDispatcherEdit { get; set; }

		[DataMember]
		[Column("IsDispatcherEditLdg")]
		public bool? IsDispatcherEditLdg { get; set; }

		[DataMember]
		[Column("StatusId")]
		public int StatusId { get; set; }

		[DataMember]
		[Child]
		public FlightPlanOpsDTO ParentFlightPlanOps { get; set; }

		[DataMember]
		[Include]
		public ReasonDTO DelayReason { get; set; }

		[DataMember]
		[Include]
		public ReasonDTO Reason { get; set; }

		[DataMember]
		[Include]
		public ReasonDTO CancelReason { get; set; }
	}
}