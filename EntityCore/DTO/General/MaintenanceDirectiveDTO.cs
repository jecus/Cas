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
	[Table("MaintenanceDirectives", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class MaintenanceDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("TaskNumberCheck"), MaxLength(256)]
		public string TaskNumberCheck { get; set; }

		[DataMember]
		[Column("DirectiveTypeId")]
		public int? DirectiveTypeId { get; set; }

		[DataMember]
		[Column("MPDTaskNumber"), MaxLength(256)]
		public string MPDTaskNumber { get; set; }

		[DataMember]
		[Column("MPDNumber"), MaxLength(256)]
		public string MPDNumber { get; set; }

		[DataMember]
		[Column("MaintenanceManual"), MaxLength(512)]
		public string MaintenanceManual { get; set; }

		[DataMember]
		[Column("Zone"), MaxLength(256)]
		public string Zone { get; set; }

		[DataMember]
		[Column("Access")]
		public string Access { get; set; }

		[DataMember]
		[Column("Applicability"), MaxLength(256)]
		public string Applicability { get; set; }

		[DataMember]
		[Column("ATAChapter")]
		public int? ATAChapterId { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("EngineeringOrders"), MaxLength(256)]
		public string EngineeringOrders { get; set; }

		[DataMember]
		[Column("ServiceBulletinNo"), MaxLength(256)]
		public string ServiceBulletinNo { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(116)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("HiddenRemarks"), MaxLength(512)]
		public string HiddenRemarks { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("Elapsed")]
		public double? Elapsed { get; set; }

		[DataMember]
		[Column("MRB"), MaxLength(256)]
		public string MRB { get; set; }

		[DataMember]
		[Column("TaskCardNumber"), MaxLength(256)]
		public string TaskCardNumber { get; set; }

		[DataMember]
		[Column("Program")]
		public int? Program { get; set; }

		[DataMember]
		[Column("CriticalSystem")]
		public int? CriticalSystem { get; set; }

		[DataMember]
		[Column("MaintenanceCheck")]
		public int? MaintenanceCheckId { get; set; }

		[DataMember]
		[Column("PrintInWP"), Required]
		public bool PrintInWP { get; set; }

		[DataMember]
		[Column("JobCard")]
		public int? JobCardId { get; set; }

		[DataMember]
		[Column("NDTType"), Required]
		public short NDTType { get; set; }

		[DataMember]
		[Column("KitsApplicable"), Required]
		public bool KitsApplicable { get; set; }

		[DataMember]
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		[DataMember]
		[Column("ForComponentId")]
		public int? ForComponentId { get; set; }

		[DataMember]
		[Column("MpdRef"), MaxLength(256)]
		public string MpdRef { get; set; }

		[DataMember]
		[Column("MpdRevisionNum"), MaxLength(256)]
		public string MpdRevisionNum { get; set; }

		[DataMember]
		[Column("MpdOldTaskCard"), MaxLength(256)]
		public string MpdOldTaskCard { get; set; }

		[DataMember]
		[Column("Workarea"), MaxLength(256)]
		public string Workarea { get; set; }

		[DataMember]
		[Column("MpdRevisionDate")]
		public DateTime? MpdRevisionDate { get; set; }

		[DataMember]
		[Column("Category"), Required]
		public int Category { get; set; }

		[DataMember]
		[Column("Skill"), Required]
		public int Skill { get; set; }

		[DataMember]
		[Column("ScheduleItem"), MaxLength(256)]
		public string ScheduleItem { get; set; }

		[DataMember]
		[Column("ScheduleRef"), MaxLength(256)]
		public string ScheduleRef { get; set; }

		[DataMember]
		[Column("ScheduleRevisionNum"), MaxLength(256)]
		public string ScheduleRevisionNum { get; set; }

		[DataMember]
		[Column("ScheduleRevisionDate")]
		public DateTime? ScheduleRevisionDate { get; set; }

		[DataMember]
		[Column("IsApplicability")]
		public bool IsApplicability { get; set; }

		[DataMember]
		[Column("IsOperatorTask")]
		public bool IsOperatorTask { get; set; }

		[DataMember]
		[Column("ProgramIndicator")]
		public int ProgramIndicator { get; set; }

		[DataMember]
		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[DataMember]
		[Include]
		public ComponentDTO BaseComponent { get; set; }


		[DataMember]
		[Child]
		public MaintenanceCheckDTO MaintenanceCheck { get; set; }

		[DataMember]
		[Child]
		public JobCardDTO JobCard { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		#region Navigation Property

		[DataMember]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion

	}
}