using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentLLPCategoryChangeRecordMap : BaseMap<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordMap() : base()
		{
			HasRequired(i => i.ToCategory)
				.WithMany(i => i.CategoryChangeRecordDto)
				.HasForeignKey(i => i.ToCategoryId);

			HasMany(i => i.Files).WithRequired(i => i.CategoryChangeRecord).HasForeignKey(i => i.ParentId);
		}
	}
}