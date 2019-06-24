using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentLLPCategoryDataMap : BaseMap<ComponentLLPCategoryDataDTO>
	{
		public ComponentLLPCategoryDataMap() : base()
		{
			HasRequired(i => i.ParentCategory)
				.WithMany(i => i.CategoryDataDtos)
				.HasForeignKey(i => i.LLPCategoryId);

		}
	}
}