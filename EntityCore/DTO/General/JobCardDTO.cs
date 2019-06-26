using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("JobCards", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class JobCardDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentId")]
		public int ParentId { get; set; }

		[DataMember]
		[Column("WorkArea"), MaxLength(256)]
		public string WorkArea { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("Form"), MaxLength(256)]
		public string Form { get; set; }

		[DataMember]
		[Column("FormRevision"), MaxLength(256)]
		public string FormRevision { get; set; }

		[DataMember]
		[Column("FormDate")]
		public DateTime? FormDate { get; set; }

		[DataMember]
		[Column("PreparedByDate")]
		public DateTime? PreparedByDate { get; set; }

		[DataMember]
		[Column("PreparedById")]
		public int? PreparedById { get; set; }

		[DataMember]
		[Column("CheckedByDate")]
		public DateTime? CheckedByDate { get; set; }

		[DataMember]
		[Column("CheckedById")]
		public int? CheckedById { get; set; }

		[DataMember]
		[Column("ApprovedByDate")]
		public DateTime? ApprovedByDate { get; set; }

		[DataMember]
		[Column("ApprovedById")]
		public int? ApprovedById { get; set; }

		[DataMember]
		[Column("JobCardNumber"), MaxLength(256)]
		public string JobCardNumber { get; set; }

		[DataMember]
		[Column("JobCardHeader"), MaxLength(256)]
		public string JobCardHeader { get; set; }

		[DataMember]
		[Column("JobCardDate")]
		public DateTime? JobCardDate { get; set; }

		[DataMember]
		[Column("JobCardRevision"), MaxLength(256)]
		public string JobCardRevision { get; set; }

		[DataMember]
		[Column("JobCardRevisionDate")]
		public DateTime? JobCardRevisionDate { get; set; }

		[DataMember]
		[Column("Title"), MaxLength(256)]
		public string Title { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(256)]
		public string Description { get; set; }

		[DataMember]
		[Column("AtaChapter")]
		public int? AtaChapterId { get; set; }

		[DataMember]
		[Column("Zone"), MaxLength(256)]
		public string Zone { get; set; }

		[DataMember]
		[Column("Access"), MaxLength(256)]
		public string Access { get; set; }

		[DataMember]
		[Column("Station"), MaxLength(256)]
		public string Station { get; set; }

		[DataMember]
		[Column("MRO"), MaxLength(256)]
		public string MRO { get; set; }

		[DataMember]
		[Column("MaintenanceManualRevision"), MaxLength(256)]
		public string MaintenanceManualRevision { get; set; }

		[DataMember]
		[Column("MaintenanceManualRevisionDate")]
		public DateTime? MaintenanceManualRevisionDate { get; set; }

		[DataMember]
		[Column("Qualification")]
		public int? QualificationId { get; set; }

		[DataMember]
		[Column("Man")]
		public int? Man { get; set; }

		[DataMember]
		[Column("JobCardFooter"), MaxLength(256)]
		public string JobCardFooter { get; set; }

		[DataMember]
		[Column("Phase"), MaxLength(256)]
		public string Phase { get; set; }

		[DataMember]
		[Column("Applicability"), MaxLength(256)]
		public string Applicability { get; set; }

		[DataMember]
		[Column("RefDocType")]
		public int? RefDocType { get; set; }

		[DataMember]
		[Column("DirectiveTypeId")]
		public int? DirectiveTypeId { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO PreparedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO CheckedBy { get; set; }

		[DataMember]
		[Include]
		public SpecialistDTO ApprovedBy { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO AtaChapter { get; set; }

		[DataMember]
		[Include]
		public AircraftWorkerCategoryDTO Qualification { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1450)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		[DataMember]
		[Child]
		public ICollection<JobCardTaskDTO> JobCardTasks { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<ProcedureDTO> Procedure { get; set; }
		[DataMember]
		public ICollection<MaintenanceDirectiveDTO> MaintenanceDirectiveDtos { get; set; }
		[DataMember]
		public ICollection<JobCardTaskDTO> JobCardTaskDtos { get; set; }

		#endregion
	}
}