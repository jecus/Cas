using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsLicenseRating", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseRatingDTO : BaseEntity
	{
		
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("RightsId"), Required]
		public int RightsId { get; set; }

		
		[Column("FunctionId"), Required]
		public int FunctionId { get; set; }

		#region Navigation Property

		
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion

	}
}