using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightPlanOpsRecordsMap : BaseMap<FlightPlanOpsRecordsDTO>
	{
		public FlightPlanOpsRecordsMap() : base()
		{
			HasRequired(i => i.ParentFlightPlanOps)
				.WithMany(i => i.FlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.FlightPlanOpsId);

			HasRequired(i => i.DelayReason)
				.WithMany(i => i.DelayFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.DelayReasonId);

			HasRequired(i => i.Reason)
				.WithMany(i => i.ReasonFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.ReasonId);

			HasRequired(i => i.CancelReason)
				.WithMany(i => i.CancelFlightPlanOpsRecordsDtos)
				.HasForeignKey(i => i.CancelReasonId);
		}
	}
}