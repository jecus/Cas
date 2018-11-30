using System;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDetailDTO : BaseEntity
	{
		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public DateTime IssueDate { get; set; }

		[DataMember]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		public int SpecialistId { get; set; }

		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }


		#endregion
	}
}