using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentLLPCategoryDataMap : BaseMap<ComponentLLPCategoryDataDTO>
	{
		public ComponentLLPCategoryDataMap() : base()
		{
			ToTable("dbo.ComponentLLPCategoryData");

			Property(i => i.LLPCategoryId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPCategoryId");

			Property(i => i.LLPLifeLength)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPLifeLength");

			Property(i => i.LLPLifeLimit)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPLifeLimit");

			Property(i => i.Notify)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.ComponentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentId");

			Property(i => i.LLPLifeLengthCurrent)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPLifeLengthCurrent");

			Property(i => i.LLPLifeLengthForDate)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPLifeLengthForDate");

			Property(i => i.Date)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Date");

			HasRequired(i => i.ParentCategory)
				.WithMany(i => i.CategoryDataDtos)
				.HasForeignKey(i => i.LLPCategoryId);

		}
	}
}