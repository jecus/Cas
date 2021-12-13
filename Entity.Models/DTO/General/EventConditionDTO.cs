using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Entity.Models.DTO.General
{
	[Table("EventConditions", Schema = "dbo")]
	
	public class EventConditionDTO : BaseEntity
	{
		
		[Column("EventConditionTypeId")]
		public int? EventConditionTypeId { get; set; }

		
		[Column("ValueId")]
		public int? ValueId { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public EventDTO Event { get; set; }

		#endregion
	}
}