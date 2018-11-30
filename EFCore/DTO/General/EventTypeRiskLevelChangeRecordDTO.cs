using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class EventTypeRiskLevelChangeRecordDTO : BaseEntity
	{
		[DataMember]
		public int? EventCategoryId { get; set; }

		[DataMember]
		public int? EventClassId { get; set; }

		[DataMember]
		public int? IncidentTypeId { get; set; }

		[DataMember]
		public DateTime? RecordDate { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		[Include]
		public EventCategorieDTO EventCategory { get; set; }

		[DataMember]
		[Include]
		public EventClassDTO EventClass { get; set; }

		[DataMember]
		[Include]
		public SmsEventTypeDTO ParentEventType { get; set; }

	}
}