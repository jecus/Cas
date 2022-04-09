using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SmsEventTypes", Schema = "dbo")]
	
	public class CAASmsEventTypeDTO : BaseEntity
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

		
		[Column("Description"), MaxLength(128)]
		public string Description { get; set; }
		
		[Column("OperatorId")]
		public int OperatorId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public ICollection<CAAEventDTO> EventDtos { get; set; }
		[JsonIgnore]
		public ICollection<CAAEventTypeRiskLevelChangeRecordDTO> ChangeRecordDtos { get; set; }

		#endregion
	}
}