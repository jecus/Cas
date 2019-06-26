using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
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
		[Column("RightsId")]
		public int? RightsId { get; set; }

		[DataMember]
		[Column("RestrictionId")]
		public int? RestrictionId { get; set; }

		[DataMember]
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		[DataMember]
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

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