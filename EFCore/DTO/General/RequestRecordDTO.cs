using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class RequestRecordDTO : BaseEntity
	{
		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public int? DirectivesId { get; set; }

		[DataMember]
		public int? PackageItemTypeId { get; set; }

		#region Navigation Property

		[DataMember]
		public RequestDTO RequestDto { get; set; }

		#endregion
	}
}