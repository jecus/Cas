using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.DTO.General
{
	[Table("SmsEventTypes", Schema = "dbo")]
	
	public class SmsEventTypeDTO : BaseEntity
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		
		[Column("Description"), MaxLength(128)]
		public string Description { get; set; }

		#region Navigation Property

		
		public ICollection<EventDTO> EventDtos { get; set; }
		
		public ICollection<EventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

		#endregion
	}
}