using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class AttachedFileMap : EntityTypeConfiguration<AttachedFileDTO>
	{
		public AttachedFileMap()
		{
			ToTable("dbo.Files");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.FileName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileName");

			Property(i => i.FileData)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileData");

			Property(i => i.FileSize)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
				.HasColumnName("FileSize");

			Property(i => i.StoreInDatabase)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StoreInDatabase");

			Property(i => i.FilePath)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FilePath");
		}
	}
}