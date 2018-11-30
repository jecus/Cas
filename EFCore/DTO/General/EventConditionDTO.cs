using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class EventConditionDTO : BaseEntity
	{
		[DataMember]
		public int? EventConditionTypeId { get; set; }

		[DataMember]
		public int? ValueId { get; set; }

		[DataMember]
		public int? ParentId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		#region Navigation Property

		[DataMember]
		public EventDTO Event { get; set; }

		#endregion
	}
}