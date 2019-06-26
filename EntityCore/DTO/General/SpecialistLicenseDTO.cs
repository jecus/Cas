using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsLicense", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDTO : BaseEntity
	{
		
		[Column("Confirmation"), Required]
		public bool Confirmation { get; set; }

		
		[Column("LicenseTypeID"), Required]
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

		
		[Include]
		public AccessoryDescriptionDTO AircraftType { get; set; }

		
		[Child]
		public ICollection<SpecialistCAADTO> CaaLicense { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseRatingDTO> LicenseRatings { get; set; }

		
		[Child]
		public ICollection<SpecialistInstrumentRatingDTO> SpecialistInstrumentRatings { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseRemarkDTO> LicenseRemark { get; set; }


		#region Navigation Property

		
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}