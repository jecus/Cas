using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceCheckBindTaskRecordMap : EntityTypeConfiguration<MaintenanceCheckBindTaskRecordDTO>
	{
		public MaintenanceCheckBindTaskRecordMap()
		{
			ToTable("dbo.MaintenanceChecksBindTaskRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.CheckId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckId");

			Property(i => i.CheckPerformaceNum)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckPerformaceNum");

			Property(i => i.CheckPerformaceGroupNum)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckPerformaceGroupNum");

			Property(i => i.TaskId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskId");

			Property(i => i.TaskTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskTypeId");

			Property(i => i.TaskPerfNumFromStart)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskPerfNumFromStart");

			Property(i => i.TaskPerfNumFromRecord)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskPerfNumFromRecord");

			Property(i => i.TaskFromRecordId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TaskFromRecordId");

			Property(i => i.WorkPackageId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageId");
		}
	}
}