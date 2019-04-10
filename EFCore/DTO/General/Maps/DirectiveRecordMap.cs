using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DirectiveRecordMap : BaseMap<DirectiveRecordDTO>
	{
		public DirectiveRecordMap() : base()
		{
			ToTable("dbo.DirectivesRecords");

			Property(i => i.NumGroup)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NumGroup");

			Property(i => i.RecordTypeID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordTypeID");

			Property(i => i.ParentID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentID");

			Property(i => i.ParentTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.Remarks)
				.HasMaxLength(1024)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.RecordDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.OnLifelength)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnLifelength");

			Property(i => i.Unused)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Unused");

			Property(i => i.Overused)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Overused");

			Property(i => i.WorkPackageID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageID");

			Property(i => i.Dispatched)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Dispatched");

			Property(i => i.Completed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Completed");

			Property(i => i.Reference)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Reference");

			Property(i => i.ODR)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ODR");

			Property(i => i.MaintenanceOrganization)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceOrganization");

			Property(i => i.MaintenanceDirectiveRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceDirectiveRecordId");

			Property(i => i.MaintenanceCheckRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceCheckRecordId");

			Property(i => i.PerformanceNum)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerformanceNum");

			Property(i => i.IsControlPoint)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsControlPoint");

			Property(i => i.CalculatedPerformanceSource)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CalculatedPerformanceSource");

			Property(i => i.ComplianceCheckName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComplianceCheckName");



			HasMany(i => i.Files).WithRequired(i => i.DirectiveRecord).HasForeignKey(i => i.ParentId);
			HasMany(i => i.FilesForMaintenanceCheckRecord).WithRequired(i => i.MaintenanceCheckRecord).HasForeignKey(i => i.ParentId);
		}
	}
}