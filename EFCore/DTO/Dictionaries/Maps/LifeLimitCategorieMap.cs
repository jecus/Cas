using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LifeLimitCategorieMap : BaseMap<LifeLimitCategorieDTO>
	{
		public LifeLimitCategorieMap() : base()
		{
			
			#region relation

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.LifeLimitCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			#endregion
		}
	}
}