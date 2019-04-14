using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class ATAChapterMap : BaseMap<ATAChapterDTO>
	{
		public ATAChapterMap() : base()
		{
			ToTable("Dictionaries.ATAChapter");

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