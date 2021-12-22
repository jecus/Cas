using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsLicenseRating", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistLicenseRatingDTO : BaseEntity
	{
		
		[Column("IssueDate")]
		public DateTime IssueDate { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("RightsId")]
		public int RightsId { get; set; }

		
		[Column("FunctionId")]
		public int FunctionId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion

	}
}