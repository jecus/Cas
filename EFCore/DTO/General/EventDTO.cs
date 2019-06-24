using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("Events", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class EventDTO : BaseEntity
	{
		[DataMember]
		[Column("EventTypeId")]
		public int? EventTypeId { get; set; }

		[DataMember]
		[Column("EventCategoryId")]
		public int? EventCategoryId { get; set; }

		[DataMember]
		[Column("EventClassId")]
		public int? EventClassId { get; set; }

		[DataMember]
		[Column("IncidentTypeId")]
		public int? IncidentTypeId { get; set; }

		[DataMember]
		[Column("RecordDate")]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(128)]
		public string Description { get; set; }

		[DataMember]
		[Column("EventStatusId")]
		public int? EventStatusId { get; set; }

		[DataMember]
		[Column("AircraftId")]
		public int? AircraftId { get; set; }


		[DataMember]
		[Include]
		public SmsEventTypeDTO EventType { get; set; }

		[DataMember]
		[Include]
		public EventCategorieDTO EventCategory { get; set; }

		[DataMember]
		[Include]
		public EventClassDTO EventClass { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 12)]
		public ICollection<EventConditionDTO> EventConditions { get; set; }
	}
}