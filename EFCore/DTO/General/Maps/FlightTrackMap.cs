using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightTrackMap : BaseMap<FlightTrackDTO>
	{
		public FlightTrackMap() : base()
		{
			HasRequired(i => i.TripName)
				.WithMany(i => i.FlightTrackDtos)
				.HasForeignKey(i => i.TripNameId);

			HasRequired(i => i.Supplier)
				.WithMany(i => i.FlightTrackDtos)
				.HasForeignKey(i => i.SupplierID);

			HasMany(i => i.FlightTripRecord).WithRequired(i => i.FlightTrack).HasForeignKey(i => i.FlightTripId);
		}
	}
}