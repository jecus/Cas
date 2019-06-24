using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class VehicleMap : BaseMap<VehicleDTO>
	{
		public VehicleMap() : base()
		{

			HasRequired(i => i.Model)
				.WithMany(i => i.VehicleDtos)
				.HasForeignKey(i => i.ModelId);
		}
	}
}