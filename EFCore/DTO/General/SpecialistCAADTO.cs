using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("SpecialistsCAA", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistCAADTO : BaseEntity
	{
		[DataMember]
		[Column("NumberCAA"), MaxLength(25)]
		public string NumberCAA { get; set; }

		[DataMember]
		[Column("CAAId"), Required]
		public int CAAId { get; set; }

		[DataMember]
		[Column("CAAType"), Required]
		public int CAAType { get; set; }

		[DataMember]
		[Column("ValidTo"), Required]
		public DateTime ValidTo { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("IssueDate")]
		public DateTime? IssueDate { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}