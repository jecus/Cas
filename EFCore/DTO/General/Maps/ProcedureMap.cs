using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ProcedureMap : BaseMap<ProcedureDTO>
	{
		public ProcedureMap() : base()
		{
			ToTable("dbo.Procedures");

			Property(i => i.Title)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.ProcedureTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProcedureTypeId");

			Property(i => i.Applicability)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Applicability");

			Property(i => i.OperatorId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OperatorId");

			Property(i => i.AuditedObjectId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuditedObjectId");

			Property(i => i.AuditedObjectTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuditedObjectTypeId");

			Property(i => i.Description)
				.HasMaxLength(3072)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.CheckList)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckList");

			Property(i => i.CheckListFileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckListFileId");

			Property(i => i.ProcedureFileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProcedureFileId");

			Property(i => i.JobCardId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCard");

			Property(i => i.Threshold)
				.HasMaxLength(116)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.Remarks)
				.HasMaxLength(512)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.HiddenRemarks)
				.HasMaxLength(512)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Elapsed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Elapsed");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.PrintInWP)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PrintInWP");

			Property(i => i.ProcedureRatingId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProcedureRatingId");

			Property(i => i.Level)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Level");

			Property(i => i.AuditedObject)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuditedObject");

			HasRequired(i => i.JobCard)
				.WithMany(i => i.Procedure)
				.HasForeignKey(i => i.JobCardId);

			HasMany(i => i.Files).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PerformanceRecords).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentID);
			HasMany(i => i.DocumentReferences).WithRequired(i => i.ProcedureDto).HasForeignKey(i => i.ProcedureId);
			HasMany(i => i.Kits).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentId);

		}
	}
}