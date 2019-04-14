using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MaintenanceCheckBindTaskRecordMap : BaseMap<MaintenanceCheckBindTaskRecordDTO>
	{
		public MaintenanceCheckBindTaskRecordMap() : base()
		{
			ToTable("dbo.MaintenanceChecksBindTaskRecords");

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