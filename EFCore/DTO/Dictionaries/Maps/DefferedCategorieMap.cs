using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DefferedCategorieMap : BaseMap<DefferedCategorieDTO>
	{
		public DefferedCategorieMap() : base()
		{
			
			#region relation

			HasRequired(i => i.AccessoryDescription)
				.WithMany(i => i.DefferedCategorieDtos)
				.HasForeignKey(i => i.AircraftModelId);

			#endregion
		}
	}
}