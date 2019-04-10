using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DiscrepancyMap : BaseMap<DiscrepancyDTO>
	{
		public DiscrepancyMap() : base()
		{
			ToTable("dbo.Discrepancies");

			Property(i => i.FlightID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightID");

			Property(i => i.FilledBy)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FilledBy");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.PilotRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PilotRemarks");

			Property(i => i.ATAChapterID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATAChapterID");

			Property(i => i.DirectiveId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveId");

			Property(i => i.Num)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Num");

			Property(i => i.WorkPackageId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageId");

			Property(i => i.Status)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Status");

			Property(i => i.IsReliability)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsReliability");

			Property(i => i.IsOccurrence)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsOccurrence");

			Property(i => i.Substruction)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Substruction");

			Property(i => i.EngineShutUp)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineShutUp");

			Property(i => i.DeffeсtPhase)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeffeсtPhase");

			Property(i => i.DeffeсtCategory)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeffeсtCategory");

			Property(i => i.DeffectConfirm)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeffectConfirm");

			Property(i => i.ActionType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ActionType");

			Property(i => i.ConsequenceFault)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ConsequenceFault");

			Property(i => i.ConsequenceOps)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ConsequenceOps");

			Property(i => i.TimeDelay)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeDelay");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.EngineRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EngineRemarks");

			Property(i => i.Messages)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Messages");

			Property(i => i.FDR)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FDR");

			Property(i => i.ConsequenceType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ConsequenceType");

			Property(i => i.InterruptionType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("InterruptionType");

			Property(i => i.AuthId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Auth");

			Property(i => i.BaseComponentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BaseComponentId");

			Property(i => i.Occurrence)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Occurrence");


			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.ATAChapterID);

			HasRequired(i => i.Auth)
				.WithMany(i => i.DiscrepancyDtos)
				.HasForeignKey(i => i.AuthId);



		}
	}
}