using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAircraftModelRelationMap : BaseMap<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationMap() : base()
		{
			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.AircraftModel)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.AircraftModelId);
		}
	}
}