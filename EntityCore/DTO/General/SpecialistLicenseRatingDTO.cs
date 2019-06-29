using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsLicenseRating", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRatingDTO : BaseEntity
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
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion

	}
}