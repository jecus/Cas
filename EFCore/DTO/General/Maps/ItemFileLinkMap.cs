using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ItemFileLinkMap : BaseMap<ItemFileLinkDTO>
	{
		public ItemFileLinkMap() : base()
		{
			HasRequired(i => i.File)
				.WithMany(i => i.ItemFileLinkDto)
				.HasForeignKey(i => i.FileId);
		}
	}
}