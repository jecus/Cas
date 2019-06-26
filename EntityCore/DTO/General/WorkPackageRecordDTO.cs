using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Cas3WorkPakageRecord", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkPackageRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("WorkPakageId")]
		public int WorkPakageId { get; set; }

		[DataMember]
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		[DataMember]
		[Column("WorkPackageItemType")]
		public int? WorkPackageItemType { get; set; }

		[DataMember]
		[Column("PerfNumFromStart")]
		public int? PerfNumFromStart { get; set; }

		[DataMember]
		[Column("PerfNumFromRecord")]
		public int? PerfNumFromRecord { get; set; }

		[DataMember]
		[Column("FromRecordId")]
		public int? FromRecordId { get; set; }

		[DataMember]
		[Column("GroupNumber")]
		public int? Group { get; set; }

		[DataMember]
		[Column("ParentCheckId")]
		public int? ParentCheckId { get; set; }

		[DataMember]
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }
	}
}