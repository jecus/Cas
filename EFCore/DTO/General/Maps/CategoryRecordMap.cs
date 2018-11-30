using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class CategoryRecordMap : EntityTypeConfiguration<CategoryRecordDTO>
	{
		public CategoryRecordMap()
		{
			ToTable("dbo.CategoryRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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