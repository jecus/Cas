using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;

namespace Entity.Models.DTO.General
{
	[Table("MaintenanceChecksBindTaskRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckBindTaskRecordDTO : BaseEntity
	{
		
		[Column("CheckId")]
		public int? CheckId { get; set; }

		
		[Column("CheckPerformaceNum")]
		public int? CheckPerformaceNum { get; set; }

		
		[Column("CheckPerformaceGroupNum")]
		public int? CheckPerformaceGroupNum { get; set; }

		
		[Column("TaskId")]
		public int? TaskId { get; set; }

		
		[Column("TaskTypeId")]
		public int? TaskTypeId { get; set; }

		
		[Column("TaskPerfNumFromStart")]
		public int? TaskPerfNumFromStart { get; set; }

		
		[Column("TaskPerfNumFromRecord")]
		public int? TaskPerfNumFromRecord { get; set; }

		
		[Column("TaskFromRecordId")]
		public int? TaskFromRecordId { get; set; }

		
		[Column("WorkPackageId")]
		public int? WorkPackageId { get; set; }
	}
}