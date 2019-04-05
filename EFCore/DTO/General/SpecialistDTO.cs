using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public string FirstName { get; set; }

		[DataMember]
		public string ShortName { get; set; }

		[DataMember]
		public int SpecializationID { get; set; }

		[DataMember]
		public string LastName { get; set; }

		[DataMember]
		public short? Gender { get; set; }

		[DataMember]
		public int? AGWCategoryId { get; set; }

		[DataMember]
		public DateTime? DateOfBirth { get; set; }

		[DataMember]
		public string Nationality { get; set; }

		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public byte[] Photo { get; set; }

		[DataMember]
		public string PhoneMobile { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Skype { get; set; }

		[DataMember]
		public string Information { get; set; }

		[DataMember]
		public short Education { get; set; }

		[DataMember]
		public int Location { get; set; }

		[DataMember]
		public short Status { get; set; }

		[DataMember]
		public short Position { get; set; }

		[DataMember]
		public byte[] Sign { get; set; }

		[DataMember]
		public short FamilyStatus { get; set; }

		[DataMember]
		public short Citizenship { get; set; }

		[DataMember]
		public int PersonnelCategoryId { get; set; }

		[DataMember]
		public int ClassNumber { get; set; }

		[DataMember]
		public DateTime? ClassIssueDate { get; set; }

		[DataMember]
		public int GradeNumber { get; set; }

		[DataMember]
		public DateTime? GradeIssueDate { get; set; }

		[DataMember]
		public string Additional { get; set; }

		[DataMember]
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