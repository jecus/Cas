using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class PurchaseOrderMap : BaseMap<PurchaseOrderDTO>
	{
		public PurchaseOrderMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.PurchaseOrder).HasForeignKey(i => i.ParentId);
		}
	}
}