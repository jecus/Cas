using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("EventTypeRiskLevelChangeRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAAEventTypeRiskLevelChangeRecordDTO : BaseEntity
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
		
		[Column("OperatorId")]
		public int OperatorId { get; set; }

		
		[Include]
		public CAAEventCategorieDTO EventCategory { get; set; }

		
		[Include]
		public CAAEventClassDTO EventClass { get; set; }

		
		[Include]
		public CAASmsEventTypeDTO ParentEventType { get; set; }

	}
}