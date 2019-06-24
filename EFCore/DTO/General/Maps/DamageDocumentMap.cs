using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DamageDocumentMap : BaseMap<DamageDocumentDTO>
	{
		public DamageDocumentMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.DamageDocument).HasForeignKey(i => i.ParentId);

			HasMany(i => i.DamageSectors).WithRequired(i => i.DamageDocument).HasForeignKey(i => i.DamageDocumentId);
		}
	}
}