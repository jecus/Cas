using System;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsLicenseRemark", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistLicenseRemarkDTO : BaseEntity
	{
		
		[Column("IssueDate")]
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
		public CAALicenseRemarkRightDTO Rights { get; set; }

		
		[Include]
		public CAARestrictionDTO LicenseRestriction { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistLicenseDTO SpecialistLicense { get; set; }

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}