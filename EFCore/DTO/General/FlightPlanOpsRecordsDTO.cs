using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsRecordsDTO : BaseEntity
	{
		[DataMember]
		public int? FlightPlanOpsId { get; set; }

		[DataMember]
		public int? AircraftId { get; set; }

		[DataMember]
		public int? AircraftExchangeId { get; set; }

		[DataMember]
		public int? DelayReasonId { get; set; }

		[DataMember]
		public int? CancelReasonId { get; set; }

		[DataMember]
		public int? ReasonId { get; set; }

		[DataMember]
		public int? FlightTrackRecordId { get; set; }

		[DataMember]
		public int? PeriodFrom { get; set; }

		[DataMember]
		public int? PeriodTo { get; set; }

		[DataMember]
		public DateTime? PlanDate { get; set; }

		[DataMember]
		public int? ParentFlightId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public bool? IsDispatcherEdit { get; set; }

		[DataMember]
		public bool? IsDispatcherEditLdg { get; set; }

		[DataMember]
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