using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class AccessoryDescriptionMap : BaseMap<AccessoryDescriptionDTO>
	{
		public AccessoryDescriptionMap() : base()
		{
			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.AccessoryDescriptionDtos)
				.HasForeignKey(i => i.AtaChapterId);

			HasRequired(i => i.GoodStandart)
				.WithMany(i => i.AccessoryDescriptionDtos)
				.HasForeignKey(i => i.StandartId);

			HasMany(i => i.Files).WithRequired(i => i.AccessoryDescription).HasForeignKey(i => i.ParentId);

			HasMany(i => i.SupplierRelations).WithRequired(i => i.AccessoryDescriptionDto).HasForeignKey(i => i.KitId);


		}
	}
}