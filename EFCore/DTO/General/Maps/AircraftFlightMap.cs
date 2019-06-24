using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AircraftFlightMap : BaseMap<AircraftFlightDTO>
	{
		public AircraftFlightMap() : base()
		{
			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.AircraftFlightDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.Level)
				.WithMany(i => i.AircraftFlightDtos)
				.HasForeignKey(i => i.LevelId);

			HasRequired(i => i.StationFromDto)
				.WithMany(i => i.AircraftFlightsFrom)
				.HasForeignKey(i => i.StationFromId);

			HasRequired(i => i.StationToDto)
				.WithMany(i => i.AircraftFlightsTo)
				.HasForeignKey(i => i.StationToId);


			HasRequired(i => i.CancelReason)
				.WithMany(i => i.AircraftFlightsCancel)
				.HasForeignKey(i => i.CancelReasonId);

			HasRequired(i => i.DelayReason)
				.WithMany(i => i.AircraftFlightsDelay)
				.HasForeignKey(i => i.DelayReasonId);

			HasMany(i => i.Files).WithRequired(i => i.AircraftFlight).HasForeignKey(i => i.ParentId);

		}
	}
}