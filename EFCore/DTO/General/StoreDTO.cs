using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("Stores", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class StoreDTO : BaseEntity
	{
		[DataMember]
		[Column("OperatorID"), Required]
		public int OperatorID { get; set; }

		[DataMember]
		[Column("StoreName"), MaxLength(75)]
		public string StoreName { get; set; }

		[DataMember]
		[Column("Adress")]
		public string Adress { get; set; }

		[DataMember]
		[Column("Phone"), MaxLength(256)]
		public string Phone { get; set; }

		[DataMember]
		[Column("Email"), MaxLength(256)]
		public string Email { get; set; }

		[DataMember]
		[Column("Contact"), MaxLength(256)]
		public string Contact { get; set; }

		[DataMember]
		[Column("Location"), MaxLength(75)]
		public string Location { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Code"), MaxLength(256)]
		public string Code { get; set; }
	}
}