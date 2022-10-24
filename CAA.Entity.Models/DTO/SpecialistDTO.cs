using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("Specialists", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistDTO : BaseEntity, ICAAFileDtoContainer, IOperatable
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

		
		[Column("Education")]
		public short Education { get; set; }

		
		[Column("Location")]
		public int? Location { get; set; }

		
		[Column("Status")]
		public short Status { get; set; }

		
		[Column("Position")]
		public short Position { get; set; }

		
		[Column("Sign")]
		public byte[] Sign { get; set; }
		
		[Column("Stamp")]
		public byte[] Stamp { get; set; }

		
		[Column("FamilyStatus")]
		public short FamilyStatus { get; set; }

		
		[Column("Citizenship")]
		public short Citizenship { get; set; }

		
		[Column("PersonnelCategoryId")]
		public int PersonnelCategoryId { get; set; }

		
		[Column("ClassNumber")]
		public int ClassNumber { get; set; }

		
		[Column("ClassIssueDate")]
		public DateTime? ClassIssueDate { get; set; }

		
		[Column("GradeNumber")]
		public int GradeNumber { get; set; }

		
		[Column("GradeIssueDate")]
		public DateTime? GradeIssueDate { get; set; }

		
		[Column("Additional"), MaxLength(256)]
		public string Additional { get; set; }

		
		[Column("Combination")]
		public string Combination { get; set; }
		
		[Column("Qualification")]
		public string Qualification { get; set; }

        [Column("IsCAA")]
		public bool IsCAA { get; set; }


        [Column("OperatorId")]
		public int OperatorId { get; set; }
		
		
		[Column("SettingsJSON")]
		public string SettingsJSON { get; set; }


		[Include]
		public CAAAGWCategorieDTO AGWCategory { get; set; }

		
		[Include]
		public CAALocationsTypeDTO Facility { get; set; }

		
		[Include]
		public CAASpecializationDTO Specialization { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseDTO> Licenses { get; set; }

		
		[Child]
		public ICollection<CAASpecialistTrainingDTO> SpecialistTrainings { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseDetailDTO> LicenseDetails { get; set; }

		
		[Child]
		public ICollection<CAASpecialistLicenseRemarkDTO> LicenseRemark { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<CAADocumentDTO> EmployeeDocuments { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<CAACategoryRecordDTO> CategoriesRecords { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1310)]
		public ICollection<CAAItemFileLinkDTO> Files { get; set; }

    }
}