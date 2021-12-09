using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;
using ATAChapterDTO = Entity.Models.DTO.Dictionaries.ATAChapterDTO;

namespace Entity.Models.DTO.General
{
	[Table("MaintenanceDirectives", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class MaintenanceDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("TaskNumberCheck"), MaxLength(256)]
		public string TaskNumberCheck { get; set; }

		
		[Column("DirectiveTypeId")]
		public int? DirectiveTypeId { get; set; }

		
		[Column("MPDTaskNumber"), MaxLength(256)]
		public string MPDTaskNumber { get; set; }

		
		[Column("MPDNumber"), MaxLength(256)]
		public string MPDNumber { get; set; }

		
		[Column("MaintenanceManual"), MaxLength(512)]
		public string MaintenanceManual { get; set; }

		
		[Column("Zone"), MaxLength(256)]
		public string Zone { get; set; }

		
		[Column("Access")]
		public string Access { get; set; }

		
		[Column("Applicability"), MaxLength(256)]
		public string Applicability { get; set; }

		
		[Column("ATAChapter")]
		public int? ATAChapterId { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("EngineeringOrders"), MaxLength(256)]
		public string EngineeringOrders { get; set; }

		
		[Column("ServiceBulletinNo"), MaxLength(256)]
		public string ServiceBulletinNo { get; set; }

		
		[Column("Threshold"), MaxLength(116)]
		public byte[] Threshold { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("HiddenRemarks"), MaxLength(512)]
		public string HiddenRemarks { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("Elapsed")]
		public double? Elapsed { get; set; }

		
		[Column("MRB"), MaxLength(256)]
		public string MRB { get; set; }

		
		[Column("TaskCardNumber"), MaxLength(256)]
		public string TaskCardNumber { get; set; }

		
		[Column("Program")]
		public int? Program { get; set; }

		
		[Column("CriticalSystem")]
		public int? CriticalSystem { get; set; }

		
		[Column("MaintenanceCheck")]
		public int? MaintenanceCheckId { get; set; }

		
		[Column("PrintInWP")]
		public bool PrintInWP { get; set; }

		
		[Column("JobCard")]
		public int? JobCardId { get; set; }

		
		[Column("NDTType")]
		public short NDTType { get; set; }

		
		[Column("KitsApplicable")]
		public bool KitsApplicable { get; set; }

		
		[Column("ComponentId")]
		public int? ComponentId { get; set; }

		
		[Column("ForComponentId")]
		public int? ForComponentId { get; set; }

		
		[Column("MpdRef"), MaxLength(256)]
		public string MpdRef { get; set; }

		
		[Column("MpdRevisionNum"), MaxLength(256)]
		public string MpdRevisionNum { get; set; }

		
		[Column("MpdOldTaskCard"), MaxLength(256)]
		public string MpdOldTaskCard { get; set; }

		
		[Column("Workarea"), MaxLength(256)]
		public string Workarea { get; set; }

		
		[Column("MpdRevisionDate")]
		public DateTime? MpdRevisionDate { get; set; }

		
		[Column("Category")]
		public int Category { get; set; }

		
		[Column("Skill")]
		public int Skill { get; set; }

		
		[Column("ScheduleItem"), MaxLength(256)]
		public string ScheduleItem { get; set; }

		
		[Column("ScheduleRef"), MaxLength(256)]
		public string ScheduleRef { get; set; }

		
		[Column("ScheduleRevisionNum"), MaxLength(256)]
		public string ScheduleRevisionNum { get; set; }

		
		[Column("ScheduleRevisionDate")]
		public DateTime? ScheduleRevisionDate { get; set; }

		
		[Column("IsApplicability")]
		public bool IsApplicability { get; set; }

		
		[Column("IsOperatorTask")]
		public bool IsOperatorTask { get; set; }

		
		[Column("ProgramIndicator")]
		public int ProgramIndicator { get; set; }

		[Column("APUCalc")]
		public bool APUCalc { get; set; }

		[Column("IsSBControl")]
		public bool IsSBControl { get; set; }

		[Column("IsRVSM")]
		public bool IsRVSM { get; set; }

		[Column("IsETOPS")]
		public bool IsETOPS { get; set; }

		[Column("IsExtension")]
		public bool IsExtension { get; set; }

		[Column("Extension")]
		public double Extension { get; set; }

		[Column("Reference")]
		public string Reference { get; set; }

		[Column("STReference")]
		public string SourceTaskReference { get; set; }



		[Include]
		public ATAChapterDTO ATAChapter { get; set; }

		[Include]
		public ComponentDTO BaseComponent { get; set; }

		[Child]
		public MaintenanceCheckDTO MaintenanceCheck { get; set; }

		[Child]
		public JobCardDTO JobCard { get; set; }
		
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }
		
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<DirectiveRecordDTO> PerformanceRecords { get; set; }
		
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<CategoryRecordDTO> CategoriesRecords { get; set; }
		
		[Child(FilterType.Equal, "ParentTypeId", 14)]
		public ICollection<AccessoryRequiredDTO> Kits { get; set; }

		


		#region Navigation Property

		//[JsonIgnore]
		//public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion

	}
}