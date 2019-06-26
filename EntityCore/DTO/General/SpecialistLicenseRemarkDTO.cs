using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsLicenseRemark", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRemarkDTO : BaseEntity
	{
		
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		
		[Column("RightsId")]
		public int? RightsId { get; set; }

		
		[Column("RestrictionId")]
		public int? RestrictionId { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		
		[Include]
		public LicenseRemarkRightDTO Rights { get; set; }

		
		[Include]
		public RestrictionDTO LicenseRestriction { get; set; }


		#region Navigation Property

		
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}