using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class OperatorDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public byte[] LogoType { get; set; }

		[DataMember]
		public string ICAOCode { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Fax { get; set; }

		[DataMember]
		public byte[] LogoTypeWhite { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public byte[] LogotypeReportLarge { get; set; }

		[DataMember]
		public byte[] LogotypeReportVeryLarge { get; set; }

	}
}