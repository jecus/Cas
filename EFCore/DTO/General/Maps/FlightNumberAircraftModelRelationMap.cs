using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAircraftModelRelationMap : BaseMap<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationMap() : base()
		{
			ToTable("dbo.FlightNumberAircraftModelRelations");

			Property(i => i.AircraftModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftModelId");

			Property(i => i.FlightNumberId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNumberId");

			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.AircraftModel)
				.WithMany(i => i.FlightNumberAircraftModelRelationDtos)
				.HasForeignKey(i => i.AircraftModelId);
		}
	}
}