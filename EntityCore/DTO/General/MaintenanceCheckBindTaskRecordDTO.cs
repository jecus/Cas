using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("MaintenanceChecksBindTaskRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckBindTaskRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("CheckId")]
		public int? CheckId { get; set; }

		[DataMember]
		[Column("CheckPerformaceNum")]
		public int? CheckPerformaceNum { get; set; }

		[DataMember]
		[Column("CheckPerformaceGroupNum")]
		public int? CheckPerformaceGroupNum { get; set; }

		[DataMember]
		[Column("TaskId")]
		public int? TaskId { get; set; }

		[DataMember]
		[Column("TaskTypeId")]
		public int? TaskTypeId { get; set; }

		[DataMember]
		[Column("TaskPerfNumFromStart")]
		public int? TaskPerfNumFromStart { get; set; }

		[DataMember]
		[Column("TaskPerfNumFromRecord")]
		public int? TaskPerfNumFromRecord { get; set; }

		[DataMember]
		[Column("TaskFromRecordId")]
		public int? TaskFromRecordId { get; set; }

		[DataMember]
		[Column("WorkPackageId")]
		public int? WorkPackageId { get; set; }
	}
}