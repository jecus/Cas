using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("SpecialistsLicense", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDTO : BaseEntity
	{
		[DataMember]
		[Column("Confirmation"), Required]
		public bool Confirmation { get; set; }

		[DataMember]
		[Column("LicenseTypeID"), Required]
		public int LicenseTypeID { get; set; }

		[DataMember]
		[Column("AircraftTypeID"), Required]
		public int AircraftTypeID { get; set; }

		[DataMember]
		[Column("SpecialistId"), Required]
		public int SpecialistId { get; set; }

		[DataMember]
		[Column("Notify"), MaxLength(21)]
		public byte[] Notify { get; set; }

		[DataMember]
		[Column("IssueDate")]
		public DateTime? IssueDate { get; set; }

		[DataMember]
		[Column("ValidToDate")]
		public DateTime? ValidToDate { get; set; }

		[DataMember]
		[Include]
		public AccessoryDescriptionDTO AircraftType { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistCAADTO> CaaLicense { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseRatingDTO> LicenseRatings { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistInstrumentRatingDTO> SpecialistInstrumentRatings { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseRemarkDTO> LicenseRemark { get; set; }


		#region Navigation Property

		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}