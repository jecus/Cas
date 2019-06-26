using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCore.DTO.General
{
	[Table("ItemsRelations", Schema = "dbo")]
	
	public class ItemsRelationDTO : BaseEntity
	{
		
		[Column("FirstItemId"), Required]
		public int FirstItemId { get; set; }

		
		[Column("FirtsItemTypeId"), Required]
		public int FirtsItemTypeId { get; set; }

		
		[Column("SecondItemId"), Required]
		public int SecondItemId { get; set; }

		
		[Column("SecondItemTypeId"), Required]
		public int SecondItemTypeId { get; set; }

		
		[Column("RelationTypeId"), Required]
		public int RelationTypeId { get; set; }
	}
}