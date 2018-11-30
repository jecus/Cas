using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class ATAChapterMap : EntityTypeConfiguration<ATAChapterDTO>
	{
		public ATAChapterMap()
		{
			ToTable("Dictionaries.ATAChapter");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ShortName)
				.IsRequired()
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");
		}
	}
}