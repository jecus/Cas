using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("ItemsRelations", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class ItemsRelationDTO : BaseEntity
	{
		[DataMember]
		[Column("FirstItemId"), Required]
		public int FirstItemId { get; set; }

		[DataMember]
		[Column("FirtsItemTypeId"), Required]
		public int FirtsItemTypeId { get; set; }

		[DataMember]
		[Column("SecondItemId"), Required]
		public int SecondItemId { get; set; }

		[DataMember]
		[Column("SecondItemTypeId"), Required]
		public int SecondItemTypeId { get; set; }

		[DataMember]
		[Column("RelationTypeId"), Required]
		public int RelationTypeId { get; set; }
	}
}