using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class JobCardMap : EntityTypeConfiguration<JobCardDTO>
	{
		public JobCardMap()
		{
			ToTable("dbo.JobCards");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.WorkArea)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkArea");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.Form)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Form");

			Property(i => i.FormRevision)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FormRevision");

			Property(i => i.FormDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FormDate");

			Property(i => i.PreparedByDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PreparedByDate");

			Property(i => i.PreparedById)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PreparedById");

			Property(i => i.CheckedByDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckedByDate");

			Property(i => i.CheckedById)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckedById");

			Property(i => i.ApprovedByDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ApprovedByDate");

			Property(i => i.ApprovedById)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ApprovedById");

			Property(i => i.JobCardNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardNumber");

			Property(i => i.JobCardHeader)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardHeader");

			Property(i => i.JobCardDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardDate");

			Property(i => i.JobCardRevision)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardRevision");

			Property(i => i.JobCardRevisionDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardRevisionDate");

			Property(i => i.Title)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.Description)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.AtaChapterId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AtaChapter");

			Property(i => i.Zone)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Zone");

			Property(i => i.Access)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Access");

			Property(i => i.Station)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Station");

			Property(i => i.MRO)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MRO");


			Property(i => i.MaintenanceManualRevision)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceManualRevision");

			Property(i => i.MaintenanceManualRevisionDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceManualRevisionDate");

			Property(i => i.QualificationId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Qualification");

			Property(i => i.Man)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Man");

			Property(i => i.JobCardFooter)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardFooter");

			Property(i => i.Phase)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Phase");

			Property(i => i.Applicability)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Applicability");

			Property(i => i.RefDocType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RefDocType");

			Property(i => i.DirectiveTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DirectiveTypeId");

			HasRequired(i => i.PreparedBy)
				.WithMany(i => i.PreparedJobCardDtos)
				.HasForeignKey(i => i.PreparedById);

			HasRequired(i => i.CheckedBy)
				.WithMany(i => i.CheckedJobCardDtos)
				.HasForeignKey(i => i.CheckedById);

			HasRequired(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedJobCardDtos)
				.HasForeignKey(i => i.ApprovedById);

			HasRequired(i => i.AtaChapter)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.AtaChapterId);


			HasRequired(i => i.Qualification)
				.WithMany(i => i.JobCardDtos)
				.HasForeignKey(i => i.QualificationId);

			HasMany(i => i.Kits).WithRequired(i => i.JobCardDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.JobCardTasks).WithRequired(i => i.JobCardDto).HasForeignKey(i => i.JobCardId);
		}
	}
}