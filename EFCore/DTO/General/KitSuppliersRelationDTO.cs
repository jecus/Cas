using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class KitSuppliersRelationDTO : BaseEntity
	{
		[DataMember]
		public int KitId { get; set; }

		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		public int? ParentTypeId { get; set; }

		[DataMember]
		public double? CostNew { get; set; }

		[DataMember]
		public double? CostOverhaul { get; set; }

		[DataMember]
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