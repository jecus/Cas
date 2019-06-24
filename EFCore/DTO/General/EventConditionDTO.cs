using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("EventConditions", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class EventConditionDTO : BaseEntity
	{
		[DataMember]
		[Column("EventConditionTypeId")]
		public int? EventConditionTypeId { get; set; }

		[DataMember]
		[Column("ValueId")]
		public int? ValueId { get; set; }

		[DataMember]
		[Column("ParentId")]
		public int? ParentId { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		#region Navigation Property

		[DataMember]
		public EventDTO Event { get; set; }

		#endregion
	}
}