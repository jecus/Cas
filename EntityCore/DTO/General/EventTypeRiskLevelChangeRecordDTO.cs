using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("EventTypeRiskLevelChangeRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class EventTypeRiskLevelChangeRecordDTO : BaseEntity
	{
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
		[Column("Remarks"), MaxLength(128)]
		public string Remarks { get; set; }

		[DataMember]
		[Column("ParentId")]
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