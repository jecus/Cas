using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartCore.Tests.DataAccess
{
	public class ItemFileLinkMap : EntityTypeConfiguration<ItemFileLink>
	{
		public ItemFileLinkMap()
		{
			ToTable("ItemsFilesLinks", "dbo");

			// Primary Key
			HasKey(t => new { t.ItemId });

			// Properties
			Property(t => t.ItemId).HasColumnName("ItemId");

			Property(t => t.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(t => t.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(t => t.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(t => t.LinkTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LinkType");

			Property(t => t.FileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileId");
		}
		
	}
}