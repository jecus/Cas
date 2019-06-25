using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class PurchaseRequestRecordMap : BaseMap<PurchaseRequestRecordDTO>
	{
		public PurchaseRequestRecordMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.PurchaseRequestRecord).HasForeignKey(i => i.ParentId);
		}
	}
}