using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsLicenseDetail", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistLicenseDetailDTO : BaseEntity
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
		public CAASpecialistLicenseDTO SpecialistLicense { get; set; }

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }


		#endregion
	}
}