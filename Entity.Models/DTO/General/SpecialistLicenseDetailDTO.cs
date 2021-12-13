using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("SpecialistsLicenseDetail", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDetailDTO : BaseEntity
	{
		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("IssueDate")]
		public DateTime IssueDate { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		[JsonIgnore]
		public SpecialistDTO SpecialistDto { get; set; }


		#endregion
	}
}