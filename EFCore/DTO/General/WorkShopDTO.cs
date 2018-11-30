using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkShopDTO : BaseEntity
	{
		[DataMember]
		public string StoreName { get; set; }

		[DataMember]
		public string Location { get; set; }

		[DataMember]
		public int? OperatorId { get; set; }

		[DataMember]
		public string Remarks { get; set; }
	}
}