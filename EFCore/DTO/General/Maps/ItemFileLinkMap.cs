using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ItemFileLinkMap : BaseMap<ItemFileLinkDTO>
	{
		public ItemFileLinkMap() : base()
		{
			ToTable("dbo.ItemsFilesLinks");

			Property(i => i.ParentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.ParentTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.LinkType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LinkType");

			Property(i => i.FileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileId");

			HasRequired(i => i.File)
				.WithMany(i => i.ItemFileLinkDto)
				.HasForeignKey(i => i.FileId);
		}
	}
}