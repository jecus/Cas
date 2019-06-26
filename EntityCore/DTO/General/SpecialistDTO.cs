using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("Specialists", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("FirstName"), MaxLength(256)]
		public string FirstName { get; set; }

		
		[Column("ShortName"), MaxLength(256)]
		public string ShortName { get; set; }

		
		[Column("SpecializationID")]
		public int? SpecializationID { get; set; }

		
		[Column("LastName"), MaxLength(256)]
		public string LastName { get; set; }

		
		[Column("Gender")]
		public short? Gender { get; set; }

		
		[Column("AGWCategory")]
		public int? AGWCategoryId { get; set; }

		
		[Column("DateOfBirth")]
		public DateTime? DateOfBirth { get; set; }

		
		[Column("Nationality"), MaxLength(256)]
		public string Nationality { get; set; }

		
		[Column("Address"), MaxLength(256)]
		public string Address { get; set; }

		
		[Column("Photo")]
		public byte[] Photo { get; set; }

		
		[Column("PhoneMobile"), MaxLength(256)]
		public string PhoneMobile { get; set; }

		
		[Column("Phone"), MaxLength(256)]
		public string Phone { get; set; }

		
		[Column("Email"), MaxLength(256)]
		public string Email { get; set; }

		
		[Column("Skype"), MaxLength(256)]
		public string Skype { get; set; }

		
		[Column("Information"), MaxLength(256)]
		public string Information { get; set; }

		
		[Column("Education"), Required]
		public short Education { get; set; }

		
		[Column("Location")]
		public int? Location { get; set; }

		
		[Column("Status"), Required]
		public short Status { get; set; }

		
		[Column("Position"), Required]
		public short Position { get; set; }

		
		[Column("Sign")]
		public byte[] Sign { get; set; }

		
		[Column("FamilyStatus"), Required]
		public short FamilyStatus { get; set; }

		
		[Column("Citizenship"), Required]
		public short Citizenship { get; set; }

		
		[Column("PersonnelCategoryId"), Required]
		public int PersonnelCategoryId { get; set; }

		
		[Column("ClassNumber"), Required]
		public int ClassNumber { get; set; }

		
		[Column("ClassIssueDate")]
		public DateTime? ClassIssueDate { get; set; }

		
		[Column("GradeNumber"), Required]
		public int GradeNumber { get; set; }

		
		[Column("GradeIssueDate")]
		public DateTime? GradeIssueDate { get; set; }

		
		[Column("Additional"), MaxLength(256)]
		public string Additional { get; set; }

		
		[Column("Combination")]
		public string Combination { get; set; }

		
		[Include]
		public AGWCategorieDTO AGWCategory { get; set; }

		
		[Include]
		public LocationsTypeDTO Facility { get; set; }

		
		[Include]
		public SpecializationDTO Specialization { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseDTO> Licenses { get; set; }

		
		[Child]
		public ICollection<SpecialistTrainingDTO> SpecialistTrainings { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		
		[Child]
		public ICollection<SpecialistLicenseRemarkDTO> LicenseRemark { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<DocumentDTO> EmployeeDocuments { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		#region Navigation Property

		
		public ICollection<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceB1Dtos { get; set; }
		
		public ICollection<CertificateOfReleaseToServiceDTO> CertificateOfReleaseToServiceB2Dtos { get; set; }
		
		public ICollection<DiscrepancyDTO> DiscrepancyDtos { get; set; }
		
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
		
		public ICollection<WorkOrderDTO> PreparedWorkOrderDtos { get; set; }
		
		public ICollection<WorkOrderDTO> CheckedWorkOrderDtos { get; set; }
		
		public ICollection<WorkOrderDTO> ApprovedWorkOrderDtos { get; set; }
		
		public ICollection<TransferRecordDTO> ReleasedSpecialist { get; set; }
		
		public ICollection<TransferRecordDTO> RecivedSpecialist { get; set; }
		
		public ICollection<RequestDTO> PreparedByRequestDtos { get; set; }
		
		public ICollection<RequestDTO> CheckedByRequestDtos { get; set; }
		
		public ICollection<RequestDTO> ApprovedByRequestDtos { get; set; }
		
		public ICollection<JobCardDTO> PreparedJobCardDtos { get; set; }
		
		public ICollection<JobCardDTO> CheckedJobCardDtos { get; set; }
		
		public ICollection<JobCardDTO> ApprovedJobCardDtos { get; set; }

		#endregion

	}
}