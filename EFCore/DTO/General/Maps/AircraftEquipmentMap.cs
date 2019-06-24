using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AircraftEquipmentMap : BaseMap<AircraftEquipmentDTO>
	{
		public AircraftEquipmentMap() : base()
		{
			HasRequired(i => i.AircraftOtherParameter)
				.WithMany(i => i.AircraftEquipmentDtos)
				.HasForeignKey(i => i.AircraftOtherParameterId);

		}
	}
}