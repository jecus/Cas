using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DefferedCategorieMap : EntityTypeConfiguration<DefferedCategorieDTO>
	{
		public DefferedCategorieMap()
		{
			ToTable("Dictionaries.DefferedCategories");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId).HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.CategoryName)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CategoryName");

			Property(i => i.AircraftModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftModelId");

			Property(i => i.Threshold)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			#region relation

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.DefferedCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			#endregion
		}
	}
}