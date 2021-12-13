using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using Entity.Models.DTO.Dictionaries;

namespace Entity.Models.DTO.General
{
	[Table("EventTypeRiskLevelChangeRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class EventTypeRiskLevelChangeRecordDTO : BaseEntity
	{
		
		[Column("EventCategoryId")]
		public int? EventCategoryId { get; set; }

		
		[Column("EventClassId")]
		public int? EventClassId { get; set; }

		
		[Column("IncidentTypeId")]
		public int? IncidentTypeId { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Include]
		public EventCategorieDTO EventCategory { get; set; }

		
		[Include]
		public EventClassDTO EventClass { get; set; }

		
		[Include]
		public SmsEventTypeDTO ParentEventType { get; set; }

	}
}