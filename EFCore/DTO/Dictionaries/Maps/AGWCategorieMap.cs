using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class AGWCategorieMap : BaseMap<AGWCategorieDTO>
	{
		public AGWCategorieMap() : base()
		{
			ToTable("Dictionaries.AGWCategories");

			Property(i => i.FullName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.Gender)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Gender");

			Property(i => i.MinAge)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MinAge");

			Property(i => i.MaxAge)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxAge");

			Property(i => i.WeightSummer)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WeightSummer");

			Property(i => i.WeightWinter)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WeightWinter");
		}
	}
}