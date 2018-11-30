using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceCheckBindTaskRecordDTO : BaseEntity
	{
		[DataMember]
		public int? CheckId { get; set; }

		[DataMember]
		public int? CheckPerformaceNum { get; set; }

		[DataMember]
		public int? CheckPerformaceGroupNum { get; set; }

		[DataMember]
		public int? TaskId { get; set; }

		[DataMember]
		public int? TaskTypeId { get; set; }

		[DataMember]
		public int? TaskPerfNumFromStart { get; set; }

		[DataMember]
		public int? TaskPerfNumFromRecord { get; set; }

		[DataMember]
		public int? TaskFromRecordId { get; set; }

		[DataMember]
		public int? WorkPackageId { get; set; }
	}
}