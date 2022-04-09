using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("EventConditions", Schema = "dbo")]
	
	public class CAAEventConditionDTO : BaseEntity
	{
		
		[Column("EventConditionTypeId")]
		public int? EventConditionTypeId { get; set; }

		
		[Column("ValueId")]
		public int? ValueId { get; set; }

		
		[Column("ParentId")]
		public int? ParentId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }
		
		[Column("OperatorId")]
		public int OperatorId { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public CAAEventDTO Event { get; set; }

		#endregion
	}
}