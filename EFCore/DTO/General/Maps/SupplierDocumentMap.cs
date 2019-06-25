using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SupplierDocumentMap : BaseMap<SupplierDocumentDTO>
	{
		public SupplierDocumentMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.SupplierDocument).HasForeignKey(i => i.ParentId);
		}
	}
}