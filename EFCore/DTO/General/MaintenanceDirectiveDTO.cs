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
	public class MaintenanceDirectiveDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public string TaskNumberCheck { get; set; }

		[DataMember]
		public int? DirectiveTypeId { get; set; }

		[DataMember]
		public string MPDTaskNumber { get; set; }

		[DataMember]
		public string MPDNumber { get; set; }

		[DataMember]
		public string MaintenanceManual { get; set; }

		[DataMember]
		public string Zone { get; set; }

		[DataMember]
		public string Access { get; set; }

		[DataMember]
		public string Applicability { get; set; }

		[DataMember]
		public int? ATAChapterId { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string EngineeringOrders { get; set; }

		[DataMember]
		public string ServiceBulletinNo { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string HiddenRemarks { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public double? Elapsed { get; set; }

		[DataMember]
		public string MRB { get; set; }

		[DataMember]
		public string TaskCardNumber { get; set; }

		[DataMember]
		public int? Program { get; set; }

		[DataMember]
		public int? CriticalSystem { get; set; }

		[DataMember]
		public int? MaintenanceCheckId { get; set; }

		[DataMember]
		public bool PrintInWP { get; set; }

		[DataMember]
		public int? JobCardId { get; set; }

		[DataMember]
		public short NDTType { get; set; }

		[DataMember]
		public bool KitsApplicable { get; set; }

		[DataMember]
		public int? ComponentId { get; set; }

		[DataMember]
		public int? ForComponentId { get; set; }

		[DataMember]
		public string MpdRef { get; set; }

		[DataMember]
		public string MpdRevisionNum { get; set; }

		[DataMember]
		public string MpdOldTaskCard { get; set; }

		[DataMember]
		public string Workarea { get; set; }

		[DataMember]
		public DateTime? MpdRevisionDate { get; set; }

		[DataMember]
		public int Category { get; set; }

		[DataMember]
		public int Skill { get; set; }

		[DataMember]
		public string ScheduleItem { get; set; }

		[DataMember]
		public string ScheduleRef { get; set; }

		[DataMember]
		public string ScheduleRevisionNum { get; set; }

		[DataMember]
		public DateTime? ScheduleRevisionDate { get; set; }

		[DataMember]
		public bool IsApplicability { get; set; }

		[DataMember]
		public bool IsOperatorTask { get; set; }

		[DataMember]
		public int ProgramIndicator { get; set; }

		[DataMember]
		public bool APUCalc { get; set; }

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