using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AccessoryRequiredMap : BaseMap<AccessoryRequiredDTO>
	{
		public AccessoryRequiredMap() : base()
		{
			
			HasRequired(i => i.Product)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.AccessoryDescriptionId);

			HasRequired(i => i.Standart)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.GoodStandartId);

		}
	}
}