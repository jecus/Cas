using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkPackageMap : BaseMap<WorkPackageDTO>
	{
		public WorkPackageMap() : base()
		{
			ToTable("dbo.WorkPackages");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.Title)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.Status)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Status");

			Property(i => i.Author)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Author");

			Property(i => i.OpeningDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OpeningDate");

			Property(i => i.PublishingDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishingDate");

			Property(i => i.ClosingDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClosingDate");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.PublishingRemarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishingRemarks");

			Property(i => i.ClosingRemarks)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClosingRemarks");

			Property(i => i.OnceClosed)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnceClosed");

			Property(i => i.ReleaseCertificateNo)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReleaseCertificateNo");

			Property(i => i.CheckType)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckType");

			Property(i => i.Station)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Station");

			Property(i => i.MaintenanceReportNo)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceReportNo");

			Property(i => i.Number)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Number");

			Property(i => i.Revision)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Revision");

			Property(i => i.CreateDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CreateDate");

			Property(i => i.PublishedBy)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishedBy");

			Property(i => i.ClosedBy)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClosedBy");

			Property(i => i.EmployeesRemark)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EmployeesRemark");

			Property(i => i.WpWorkType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WpWorkType");

			Property(i => i.KMH)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KMH");

			Property(i => i.PerformAfter)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerformAfter");

			Property(i => i.ProviderJSON)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProviderJSON");


			HasMany(i => i.Files).WithRequired(i => i.WorkPackage).HasForeignKey(i => i.ParentId);
		} 
	}
}