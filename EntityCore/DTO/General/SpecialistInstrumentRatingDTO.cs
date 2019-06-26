using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsInstrumentRating", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistInstrumentRatingDTO : BaseEntity
	{
		
		[Column("IssueDate"), Required]
		public DateTime IssueDate { get; set; }

		
		[Column("SpecialistLicenseId")]
		public int? SpecialistLicenseId { get; set; }

		
		[Column("IcaoId"), Required]
		public int IcaoId { get; set; }

		
		[Column("MC"), Required]
		public int MC { get; set; }

		
		[Column("MV"), Required]
		public int MV { get; set; }

		
		[Column("RVR"), Required]
		public int RVR { get; set; }

		
		[Column("TORVR"), Required]
		public int TORVR { get; set; }

		#region Navigation Property

		
		public SpecialistLicenseDTO SpecialistLicense { get; set; }

		#endregion
	}
}