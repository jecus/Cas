using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class EventDTO : BaseEntity
	{
		[DataMember]
		public int? EventTypeId { get; set; }

		[DataMember]
		public int? EventCategoryId { get; set; }

		[DataMember]
		public int? EventClassId { get; set; }

		[DataMember]
		public int? IncidentTypeId { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? EventStatusId { get; set; }

		[DataMember]
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