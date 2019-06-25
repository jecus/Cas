using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("SpecialistsLicenseRemark", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRemarkDTO : BaseEntity
	{
		[DataMember]
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		[DataMember]
		[Column("RightsId"), Required]
		public int RightsId { get; set; }

		[DataMember]
		[Column("RestrictionId"), Required]
		public int RestrictionId { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId"), Required]
		public int SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("SpecialistId"), Required]
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