using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AuditRecordDTO : BaseEntity
	{
		[DataMember]
		public int AuditId { get; set; }

		[DataMember]
		public int? DirectivesId { get; set; }

		[DataMember]
		public int? AuditItemTypeId { get; set; }

		[DataMember]
		public int? PerfNumFromStart { get; set; }

		[DataMember]
		public int? PerfNumFromRecord { get; set; }

		[DataMember]
		public int? FromRecordId { get; set; }

		[DataMember]
		public string JobCardNumber { get; set; }


		#region Navigation Property

		[DataMember]
		public AuditDTO Audit { get; set; }

		#endregion
	}
}