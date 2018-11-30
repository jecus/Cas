using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class JobCardDTO : BaseEntity
	{
		[DataMember]
		public int ParentId { get; set; }

		[DataMember]
		public string WorkArea { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public string Form { get; set; }

		[DataMember]
		public string FormRevision { get; set; }

		[DataMember]
		public DateTime? FormDate { get; set; }

		[DataMember]
		public DateTime? PreparedByDate { get; set; }

		[DataMember]
		public int? PreparedById { get; set; }

		[DataMember]
		public DateTime? CheckedByDate { get; set; }

		[DataMember]
		public int? CheckedById { get; set; }

		[DataMember]
		public DateTime? ApprovedByDate { get; set; }

		[DataMember]
		public int? ApprovedById { get; set; }

		[DataMember]
		public string JobCardNumber { get; set; }

		[DataMember]
		public string JobCardHeader { get; set; }

		[DataMember]
		public DateTime? JobCardDate { get; set; }

		[DataMember]
		public string JobCardRevision { get; set; }

		[DataMember]
		public DateTime? JobCardRevisionDate { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? AtaChapterId { get; set; }

		[DataMember]
		public string Zone { get; set; }

		[DataMember]
		public string Access { get; set; }

		[DataMember]
		public string Station { get; set; }

		[DataMember]
		public string MRO { get; set; }

		[DataMember]
		public string MaintenanceManualRevision { get; set; }

		[DataMember]
		public DateTime? MaintenanceManualRevisionDate { get; set; }

		[DataMember]
		public int? QualificationId { get; set; }

		[DataMember]
		public int? Man { get; set; }

		[DataMember]
		public string JobCardFooter { get; set; }

		[DataMember]
		public string Phase { get; set; }

		[DataMember]
		public string Applicability { get; set; }

		[DataMember]
		public int? RefDocType { get; set; }

		[DataMember]
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