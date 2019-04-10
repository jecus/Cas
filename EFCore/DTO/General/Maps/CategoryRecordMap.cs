using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class CategoryRecordMap : BaseMap<CategoryRecordDTO>
	{
		public CategoryRecordMap() : base()
		{
			ToTable("dbo.CategoryRecords");

			Property(i => i.EmployeeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EmployeeId");

			Property(i => i.AircraftWorkerCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftWorkerCategoryId");

			Property(i => i.AircraftTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftTypeId");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");


			HasRequired(i => i.AircraftModel)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftTypeId);

			HasRequired(i => i.AircraftWorkerCategory)
				.WithMany(i => i.CategoryRecordDtos)
				.HasForeignKey(i => i.AircraftWorkerCategoryId);
		}
	}
}