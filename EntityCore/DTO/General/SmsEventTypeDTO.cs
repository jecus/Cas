using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("SmsEventTypes", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class SmsEventTypeDTO : BaseEntity
	{
		[DataMember]
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		[DataMember]
		[Column("Description"), MaxLength(128)]
		public string Description { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<EventDTO> EventDtos { get; set; }
		[DataMember]
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

		#endregion
	}
}