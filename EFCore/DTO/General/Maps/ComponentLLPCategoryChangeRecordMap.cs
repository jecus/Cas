using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class ComponentLLPCategoryChangeRecordMap : EntityTypeConfiguration<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordMap()
		{
			ToTable("dbo.ComponentLLPCategoryChangeRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ParentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.ToCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ToCategoryId");

			Property(i => i.OnLifeLength)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OnLifeLength");

			Property(i => i.Remarks)
				.HasMaxLength(250)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			
			HasRequired(i => i.ToCategory)
				.WithMany(i => i.CategoryChangeRecordDto)
				.HasForeignKey(i => i.ToCategoryId);

			HasMany(i => i.Files).WithRequired(i => i.CategoryChangeRecord).HasForeignKey(i => i.ParentId);
		}
	}
}