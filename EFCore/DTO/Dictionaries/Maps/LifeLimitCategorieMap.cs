using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LifeLimitCategorieMap : EntityTypeConfiguration<LifeLimitCategorieDTO>
	{
		public LifeLimitCategorieMap()
		{
			ToTable("Dictionaries.LifeLimitCategories");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId).HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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