using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class ItemsRelationDTO : BaseEntity
	{
		[DataMember]
		public int FirstItemId { get; set; }

		[DataMember]
		public int FirtsItemTypeId { get; set; }

		[DataMember]
		public int SecondItemId { get; set; }

		[DataMember]
		public int SecondItemTypeId { get; set; }

		[DataMember]
		public int RelationTypeId { get; set; }
	}
}