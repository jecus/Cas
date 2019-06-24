using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("AuditRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AuditRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("AuditId")]
		public int? AuditId { get; set; }

		[DataMember]
		[Column("DirectivesId")]
		public int? DirectivesId { get; set; }

		[DataMember]
		[Column("AuditItemTypeId")]
		public int? AuditItemTypeId { get; set; }

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
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }


		#region Navigation Property

		[DataMember]
		public AuditDTO Audit { get; set; }

		#endregion
	}
}