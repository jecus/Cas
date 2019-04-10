using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LifeLimitCategorieMap : BaseMap<LifeLimitCategorieDTO>
	{
		public LifeLimitCategorieMap() : base()
		{
			ToTable("Dictionaries.LifeLimitCategories");

			Property(i => i.CategoryType)
				.HasMaxLength(4)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CategoryType");

			Property(i => i.CategoryName)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CategoryName");

			Property(i => i.AircraftModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftModelId");


			#region relation

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.LifeLimitCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			#endregion
		}
	}
}