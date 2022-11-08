using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsLicense", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistLicenseDTO : BaseEntity
	{
		
		[Column("Confirmation")]
		public bool Confirmation { get; set; }

		
		[Column("LicenseTypeID")]
		public int LicenseTypeID { get; set; }

		
		[Column("AircraftTypeID")]
		public int? AircraftTypeID { get; set; }

		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		
		[Column("IssueDate")]
		public DateTime? IssueDate { get; set; }

		
		[Column("ValidToDate")]
		public DateTime? ValidToDate { get; set; }
		
		[Column("IsValidTo")]
		public bool IsValidTo { get; set; }

		
		[Include]
		public CAAAccessoryDescriptionDTO AircraftType { get; set; }

		
		[Child]
		public ICollection<CAASpecialistCustomDTO> CaaLicense { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseRatingDTO> LicenseRatings { get; set; }

		
		[Child]
		public ICollection<CAASpecialistInstrumentRatingDTO> SpecialistInstrumentRatings { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseRemarkDTO> LicenseRemark { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}