using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAirportRelationMap : BaseMap<FlightNumberAirportRelationDTO>
	{
		public FlightNumberAirportRelationMap() : base()
		{
			ToTable("dbo.FlightNumberAirportRelations");

			Property(i => i.FlightNumberId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNumberId");

			Property(i => i.AirportId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AirportId");


			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.Airport)
				.WithMany(i => i.AirportRelationDtos)
				.HasForeignKey(i => i.AirportId);
		}
	}
}