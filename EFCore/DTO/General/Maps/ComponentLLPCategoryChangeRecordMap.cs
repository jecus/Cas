using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentLLPCategoryChangeRecordMap : BaseMap<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordMap() : base()
		{
			ToTable("dbo.ComponentLLPCategoryChangeRecords");

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