using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("KitSuppliers", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class KitSuppliersRelationDTO : BaseEntity
	{
		
		[Column("KitId")]
		public int? KitId { get; set; }

		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		
		[Column("CostNew")]
		public double? CostNew { get; set; }

		
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		
		[Child]
		public SupplierDTO Supplier { get; set; }


		#region Navigation Property

		
		public ComponentDTO Component { get; set; }

		
		public AccessoryDescriptionDTO AccessoryDescriptionDto { get; set; }

		#endregion
	}
}