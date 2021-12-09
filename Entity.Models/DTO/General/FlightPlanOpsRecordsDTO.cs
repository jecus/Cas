using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using ReasonDTO = Entity.Models.DTO.Dictionaries.ReasonDTO;

namespace Entity.Models.DTO.General
{
	[Table("FlightPlanOpsRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class FlightPlanOpsRecordsDTO : BaseEntity
	{
		
		[Column("FlightPlanOpsId")]
		public int? FlightPlanOpsId { get; set; }

		
		[Column("AircraftId")]
		public int? AircraftId { get; set; }

		
		[Column("AircraftExchangeId")]
		public int? AircraftExchangeId { get; set; }

		
		[Column("DelayReasonId")]
		public int? DelayReasonId { get; set; }

		
		[Column("CancelReasonId")]
		public int? CancelReasonId { get; set; }

		
		[Column("ReasonId")]
		public int? ReasonId { get; set; }

		
		[Column("FlightTrackRecordId")]
		public int? FlightTrackRecordId { get; set; }

		
		[Column("PeriodFrom")]
		public int? PeriodFrom { get; set; }

		
		[Column("PeriodTo")]
		public int? PeriodTo { get; set; }

		
		[Column("PlanDate")]
		public DateTime? PlanDate { get; set; }

		
		[Column("ParentFlightId")]
		public int? ParentFlightId { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("HiddenRemarks")]
		public string HiddenRemarks { get; set; }

		
		[Column("IsDispatcherEdit")]
		public bool? IsDispatcherEdit { get; set; }

		
		[Column("IsDispatcherEditLdg")]
		public bool? IsDispatcherEditLdg { get; set; }

		
		[Column("StatusId")]
		public int StatusId { get; set; }

		
		[Child]
		public FlightPlanOpsDTO ParentFlightPlanOps { get; set; }

		
		[Include]
		public ReasonDTO DelayReason { get; set; }

		
		[Include]
		public ReasonDTO Reason { get; set; }

		
		[Include]
		public ReasonDTO CancelReason { get; set; }
	}
}