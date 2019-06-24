using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class KitSuppliersRelationMap : BaseMap<KitSuppliersRelationDTO>
	{
		public KitSuppliersRelationMap() : base()
		{
			HasRequired(i => i.Supplier)
				.WithMany(i => i.KitSuppliersRelationDtos)
				.HasForeignKey(i => i.SupplierId);
		}
	}
}