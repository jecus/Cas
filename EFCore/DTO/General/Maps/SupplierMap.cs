using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SupplierMap : BaseMap<SupplierDTO>
	{
		public SupplierMap() : base()
		{
			HasMany(i => i.SupplierDocs).WithRequired(i => i.SupplieDto).HasForeignKey(i => i.ParentID);

		}
	}
}