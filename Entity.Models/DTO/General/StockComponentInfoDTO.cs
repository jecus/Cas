using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using AccessoryDescriptionDTO = Entity.Models.DTO.Dictionaries.AccessoryDescriptionDTO;
using GoodStandartDTO = Entity.Models.DTO.Dictionaries.GoodStandartDTO;

namespace Entity.Models.DTO.General
{
	[Table("StockComponentInfos", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class StockComponentInfoDTO : BaseEntity
	{
		
		[Column("StoreID")]
		public int? StoreID { get; set; }

		
		[Column("PartNumber"), MaxLength(256)]
		public string PartNumber { get; set; }

		
		[Column("Amount")]
		public double Amount { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("AccessoryDescriptionId")]
		public int? AccessoryDescriptionId { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("GoodStandartId")]
		public int? GoodStandartId { get; set; }

		
		[Column("ComponentClass")]
		public int? ComponentClass { get; set; }

		
		[Column("ComponentModel")]
		public int? ComponentModel { get; set; }

		
		[Column("ComponentType")]
		public int? ComponentType { get; set; }

		
		[Child]
		public GoodStandartDTO Standart { get; set; }

		
		[Child]
		public AccessoryDescriptionDTO AccessoryDescription { get; set; }
	}
}