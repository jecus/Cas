using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightPlanOpsRecordsMap : BaseMap<FlightPlanOpsRecordsDTO>
	{
		public FlightPlanOpsRecordsMap() : base()
		{
			ToTable("dbo.FlightPlanOpsRecords");

			Property(i => i.FlightPlanOpsId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightPlanOpsId");

			Property(i => i.AircraftId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftId");

			Property(i => i.AircraftExchangeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftExchangeId");

			Property(i => i.DelayReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DelayReasonId");

			Property(i => i.CancelReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CancelReasonId");

			Property(i => i.ReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReasonId");

			Property(i => i.FlightTrackRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightTrackRecordId");

			Property(i => i.PeriodFrom)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PeriodFrom");

			Property(i => i.PeriodTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PeriodTo");

			Property(i => i.PlanDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PlanDate");

			Property(i => i.ParentFlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentFlightId");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.HiddenRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.IsDispatcherEdit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDispatcherEdit");

			Property(i => i.IsDispatcherEditLdg)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDispatcherEditLdg");

			Property(i => i.StatusId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StatusId");

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