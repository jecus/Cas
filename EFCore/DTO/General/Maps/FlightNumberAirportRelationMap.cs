using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAirportRelationMap : BaseMap<FlightNumberAirportRelationDTO>
	{
		public FlightNumberAirportRelationMap() : base()
		{
			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.Airport)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.AirportId);
		}
	}
}