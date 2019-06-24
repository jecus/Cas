using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class CategoryRecordMap : BaseMap<CategoryRecordDTO>
	{
		public CategoryRecordMap() : base()
		{
			HasRequired(i => i.AircraftModel)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftTypeId);

			HasRequired(i => i.AircraftWorkerCategory)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);
		}
	}
}