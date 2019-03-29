using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class StoreDTO : BaseEntity
	{
		[DataMember]
		public int OperatorID { get; set; }

		[DataMember]
		public string StoreName { get; set; }

		[DataMember]
		public string Adress { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Contact { get; set; }

		[DataMember]
		public string Location { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string Code { get; set; }
	}
}