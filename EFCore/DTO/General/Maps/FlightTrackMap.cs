using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightTrackMap : BaseMap<FlightTrackDTO>
	{
		public FlightTrackMap() : base()
		{
			ToTable("dbo.FlightTrips");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.DayOfWeek)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DayOfWeek");

			Property(i => i.TripNameId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TripName");

			Property(i => i.SupplierID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierID");

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