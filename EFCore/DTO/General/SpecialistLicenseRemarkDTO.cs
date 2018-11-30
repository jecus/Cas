using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRemarkDTO : BaseEntity
	{
		[DataMember]
		public DateTime IssueDate { get; set; }

		[DataMember]
		public int RightsId { get; set; }

		[DataMember]
		public int RestrictionId { get; set; }

		[DataMember]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		public int SpecialistId { get; set; }

		[DataMember]
		[Include]
		public LicenseRemarkRightDTO Rights { get; set; }

		[DataMember]
		[Include]
		public RestrictionDTO LicenseRestriction { get; set; }


		#region Navigation Property

		[DataMember]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}