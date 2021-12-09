using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Newtonsoft.Json;
using LicenseRemarkRightDTO = Entity.Models.DTO.Dictionaries.LicenseRemarkRightDTO;
using RestrictionDTO = Entity.Models.DTO.Dictionaries.RestrictionDTO;

namespace Entity.Models.DTO.General
{
	[Table("SpecialistsLicenseRemark", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRemarkDTO : BaseEntity
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
		public LicenseRemarkRightDTO Rights { get; set; }

		
		[Include]
		public RestrictionDTO LicenseRestriction { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[JsonIgnore]
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}