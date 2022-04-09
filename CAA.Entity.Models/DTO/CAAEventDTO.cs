using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
	[Table("Events", Schema = "dbo")]
	
	public class CAAEventDTO : BaseEntity
	{
		
		[Column("EventTypeId")]
		public int? EventTypeId { get; set; }

		
		[Column("EventCategoryId")]
		public int? EventCategoryId { get; set; }

		
		[Column("EventClassId")]
		public int? EventClassId { get; set; }

		
		[Column("IncidentTypeId")]
		public int? IncidentTypeId { get; set; }

		
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		
		[Column("Description"), MaxLength(128)]
		public string Description { get; set; }

		
		[Column("EventStatusId")]
		public int? EventStatusId { get; set; }

		
		[Column("AircraftId")]
		public int? AircraftId { get; set; }
		
		[Column("OperatorId")]
		public int OperatorId { get; set; }


		
		[Include]
		public CAASmsEventTypeDTO EventType { get; set; }

		
		[Include]
		public CAAEventCategorieDTO EventCategory { get; set; }

		
		[Include]
		public CAAEventClassDTO EventClass { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 12)]
		public ICollection<CAAEventConditionDTO> EventConditions { get; set; }
	}
}