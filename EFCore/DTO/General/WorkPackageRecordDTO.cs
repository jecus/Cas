using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkPackageRecordDTO : BaseEntity
	{
		[DataMember]
		public int WorkPakageId { get; set; }

		[DataMember]
		public int? DirectivesId { get; set; }

		[DataMember]
		public int? WorkPackageItemType { get; set; }

		[DataMember]
		public int? PerfNumFromStart { get; set; }

		[DataMember]
		public int? PerfNumFromRecord { get; set; }

		[DataMember]
		public int? FromRecordId { get; set; }

		[DataMember]
		public int? Group { get; set; }
		[DataMember]
		public int? ParentCheckId { get; set; }

		[DataMember]
		public string JobCardNumber { get; set; }
	}
}