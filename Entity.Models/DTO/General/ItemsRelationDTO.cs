using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models.DTO.General
{
	[Table("ItemsRelations", Schema = "dbo")]
	
	public class ItemsRelationDTO : BaseEntity
	{
		
		[Column("FirstItemId")]
		public int FirstItemId { get; set; }

		
		[Column("FirtsItemTypeId")]
		public int FirtsItemTypeId { get; set; }

		
		[Column("SecondItemId")]
		public int SecondItemId { get; set; }

		
		[Column("SecondItemTypeId")]
		public int SecondItemTypeId { get; set; }

		
		[Column("RelationTypeId")]
		public int RelationTypeId { get; set; }

		[Column("AdditionalInformationJSON")]
		public string AdditionalInformationJSON { get; set; }
	}
}