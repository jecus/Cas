using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistCAADTO : BaseEntity
	{
		[DataMember]
		public string NumberCAA { get; set; }

		[DataMember]
		public int CAAId { get; set; }

		[DataMember]
		public int CAAType { get; set; }

		[DataMember]
		public DateTime ValidTo { get; set; }

		[DataMember]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public DateTime? IssueDate { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}