using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DefferedCategorieMap : BaseMap<DefferedCategorieDTO>
	{
		public DefferedCategorieMap() : base()
		{
			ToTable("Dictionaries.DefferedCategories");

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