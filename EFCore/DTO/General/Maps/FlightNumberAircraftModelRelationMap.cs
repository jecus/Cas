using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAircraftModelRelationMap : EntityTypeConfiguration<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationMap()
		{
			ToTable("dbo.FlightNumberAircraftModelRelations");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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