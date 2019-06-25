using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class StockComponentInfoMap : BaseMap<StockComponentInfoDTO>
	{
		public StockComponentInfoMap() : base()
		{
			HasRequired(i => i.Standart)
				.WithMany(i => i.StockComponentInfoDtos)
				.HasForeignKey(i => i.GoodStandartId);

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.StockComponentInfoDtos)
				.HasForeignKey(i => i.ComponentModel);
		}
	}
}