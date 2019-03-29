using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistLicenseDTO : BaseEntity
	{
		[DataMember]
		public bool Confirmation { get; set; }

		[DataMember]
		public int LicenseTypeID { get; set; }

		[DataMember]
		public int AircraftTypeID { get; set; }

		[DataMember]
		public int SpecialistId { get; set; }

		[DataMember]
		public byte[] Notify { get; set; }

		[DataMember]
		public DateTime? IssueDate { get; set; }

		[DataMember]
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