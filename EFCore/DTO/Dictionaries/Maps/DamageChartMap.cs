using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DamageChartMap : BaseMap<DamageChartDTO>
	{
		public DamageChartMap() : base()
		{
			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.DamageChartDtos)
				.HasForeignKey(i => i.AircraftModelId);

			HasMany(i => i.Files).WithRequired(i => i.DamageChart).HasForeignKey(i => i.ParentId);
		}
	}
}