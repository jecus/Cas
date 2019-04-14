using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AircraftWorkerCategoryMap : BaseMap<AircraftWorkerCategoryDTO>
	{
		public AircraftWorkerCategoryMap() : base()
		{
			ToTable("dbo.AircraftWorkerCategories");

			Property(i => i.Category)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Category");
		}
	}
}