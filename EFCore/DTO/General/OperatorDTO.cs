using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("Operators", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class OperatorDTO : BaseEntity
	{
		[DataMember]
		[Column("OperatorID")]
		public override int ItemId { get; set; }

		[DataMember]
		[Column("Name"), MaxLength(50), Required]
		public string Name { get; set; }

		[DataMember]
		[Column("LogoType", TypeName = "image")]
		public byte[] LogoType { get; set; }

		[DataMember]
		[Column("ICAOCode"), MaxLength(50)]
		public string ICAOCode { get; set; }

		[DataMember]
		[Column("Address"), MaxLength(200)]
		public string Address { get; set; }

		[DataMember]
		[Column("Phone"), MaxLength(100)]
		public string Phone { get; set; }

		[DataMember]
		[Column("Fax"), MaxLength(100)]
		public string Fax { get; set; }

		[DataMember]
		[Column("LogoTypeWhite", TypeName = "image")]
		public byte[] LogoTypeWhite { get; set; }

		[DataMember]
		[Column("Email"), MaxLength(50)]
		public string Email { get; set; }

		[DataMember]
		[Column("LogotypeReportLarge", TypeName = "image")]
		public byte[] LogotypeReportLarge { get; set; }

		[DataMember]
		[Column("LogotypeReportVeryLarge", TypeName = "image")]
		public byte[] LogotypeReportVeryLarge { get; set; }

	}
}