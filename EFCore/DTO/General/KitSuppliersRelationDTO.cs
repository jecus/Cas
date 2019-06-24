using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("KitSuppliers", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class KitSuppliersRelationDTO : BaseEntity
	{
		[DataMember]
		[Column("KitId")]
		public int? KitId { get; set; }

		[DataMember]
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		[DataMember]
		[Column("ParentTypeId")]
		public int? ParentTypeId { get; set; }

		[DataMember]
		[Column("CostNew")]
		public double? CostNew { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		[DataMember]
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }


		#region Navigation Property

		[DataMember]
		public ComponentDTO Component { get; set; }

		[DataMember]
		public AccessoryDescriptionDTO AccessoryDescriptionDto { get; set; }

		#endregion
	}
}