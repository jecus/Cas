using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberAirportRelationMap : EntityTypeConfiguration<FlightNumberAirportRelationDTO>
	{
		public FlightNumberAirportRelationMap()
		{
			ToTable("dbo.FlightNumberAirportRelations");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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