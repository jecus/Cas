using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("WorkOrderRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkOrderRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		[DataMember]
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		#region Navigation Property

		[DataMember]
		public WorkOrderDTO WorkOrder { get; set; }

		#endregion
	}
}