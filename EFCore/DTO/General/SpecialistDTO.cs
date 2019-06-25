using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;
using SmartCore.Entities.General.Commercial;

namespace EFCore.DTO.General
{
	[Table("Specialists", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("FirstName"), MaxLength(256)]
		public string FirstName { get; set; }

		[DataMember]
		[Column("ShortName"), MaxLength(256)]
		public string ShortName { get; set; }

		[DataMember]
		[Column("SpecializationID")]
		public int? SpecializationID { get; set; }

		[DataMember]
		[Column("LastName"), MaxLength(256)]
		public string LastName { get; set; }

		[DataMember]
		[Column("Gender")]
		public short? Gender { get; set; }

		[DataMember]
		[Column("AGWCategory")]
		public int? AGWCategoryId { get; set; }

		[DataMember]
		[Column("DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		[DataMember]
		[Column("Nationality"), MaxLength(256)]
		public string Nationality { get; set; }

		[DataMember]
		[Column("Address"), MaxLength(256)]
		public string Address { get; set; }

		[DataMember]
		[Column("Photo")]
		public byte[] Photo { get; set; }

		[DataMember]
		[Column("PhoneMobile"), MaxLength(256)]
		public string PhoneMobile { get; set; }

		[DataMember]
		[Column("Phone"), MaxLength(256)]
		public string Phone { get; set; }

		[DataMember]
		[Column("Email"), MaxLength(256)]
		public string Email { get; set; }

		[DataMember]
		[Column("Skype"), MaxLength(256)]
		public string Skype { get; set; }

		[DataMember]
		[Column("Information"), MaxLength(256)]
		public string Information { get; set; }

		[DataMember]
		[Column("Education"), Required]
		public short Education { get; set; }

		[DataMember]
		[Column("Location")]
		public int? Location { get; set; }

		[DataMember]
		[Column("Status"), Required]
		public short Status { get; set; }

		[DataMember]
		[Column("Position"), Required]
		public short Position { get; set; }

		[DataMember]
		[Column("Sign")]
		public byte[] Sign { get; set; }

		[DataMember]
		[Column("FamilyStatus"), Required]
		public short FamilyStatus { get; set; }

		[DataMember]
		[Column("Citizenship"), Required]
		public short Citizenship { get; set; }

		[DataMember]
		[Column("PersonnelCategoryId"), Required]
		public int PersonnelCategoryId { get; set; }

		[DataMember]
		[Column("ClassNumber"), Required]
		public int ClassNumber { get; set; }

		[DataMember]
		[Column("ClassIssueDate")]
		public DateTime? ClassIssueDate { get; set; }

		[DataMember]
		[Column("GradeNumber"), Required]
		public int GradeNumber { get; set; }

		[DataMember]
		[Column("GradeIssueDate")]
		public DateTime? GradeIssueDate { get; set; }

		[DataMember]
		[Column("Additional"), MaxLength(256)]
		public string Additional { get; set; }

		[DataMember]
		[Column("Combination")]
		public string Combination { get; set; }

		[DataMember]
		[Include]
		public AGWCategorieDTO AGWCategory { get; set; }

		[DataMember]
		[Include]
		public LocationsTypeDTO Facility { get; set; }

		[DataMember]
		[Include]
		public SpecializationDTO Specialization { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseDTO> Licenses { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistTrainingDTO> SpecialistTrainings { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		[DataMember]
		[Child]
		public ICollection<SpecialistLicenseRemarkDTO> LicenseRemark { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<DocumentDTO> EmployeeDocuments { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceB1Dtos { get; set; }
		[DataMember]
		public ICollection<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceB2Dtos { get; set; }
		[DataMember]
		public ICollection<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		[DataMember]
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
		[DataMember]
		public ICollection<WorkOrderDTO> PreparedWorkOrderDtos { get; set; }
		[DataMember]
		public ICollection<WorkOrderDTO> CheckedWorkOrderDtos { get; set; }
		[DataMember]
		public ICollection<WorkOrderDTO> ApprovedWorkOrderDtos { get; set; }
		[DataMember]
		public ICollection<TransferRecordDTO> ReleasedSpecialist { get; set; }
		[DataMember]
		public ICollection<TransferRecordDTO> RecivedSpecialist { get; set; }
		[DataMember]
		public ICollection<RequestDTO> PreparedByRequestDtos { get; set; }
		[DataMember]
		public ICollection<RequestDTO> CheckedByRequestDtos { get; set; }
		[DataMember]
		public ICollection<RequestDTO> ApprovedByRequestDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> PreparedJobCardDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> CheckedJobCardDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> ApprovedJobCardDtos { get; set; }

		#endregion

	}
}