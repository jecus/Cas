using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberMap : EntityTypeConfiguration<FlightNumberDTO>
	{
		public FlightNumberMap()
		{
			ToTable("dbo.FlightNumbers");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.FlightNoId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNo");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.HiddenRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.MaxFuelAmount)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxFuelAmount");

			Property(i => i.MinFuelAmount)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MinFuelAmount");

			Property(i => i.MaxPayload)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxPayload");

			Property(i => i.MaxCargoWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxCargoWeight");

			Property(i => i.MaxTakeOffWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxTakeOffWeight");

			Property(i => i.MaxLandWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxLandWeight");

			Property(i => i.FlightAircraftCode)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightAircraftCode");

			Property(i => i.FlightType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightType");

			Property(i => i.FlightCategory)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightCategory");

			Property(i => i.Distance)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Distance");

			Property(i => i.DistanceMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DistanceMeasure");

			Property(i => i.StationFromId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationFrom");

			Property(i => i.StationToId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationTo");

			Property(i => i.MinLevelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MinLevel");

			Property(i => i.MaxPassengerAmount)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaxPassengerAmount");

			Property(i => i.Threshold)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			HasRequired(i => i.StationFrom)
				.WithMany(i => i.From)
				.HasForeignKey(i => i.StationFromId);

			HasRequired(i => i.StationTo)
				.WithMany(i => i.To)
				.HasForeignKey(i => i.StationToId);

			HasRequired(i => i.MinLevel)
				.WithMany(i => i.FlightNumberDtos)
				.HasForeignKey(i => i.MinLevelId);

			HasRequired(i => i.FlightNo)
				.WithMany(i => i.FlightNumberDtos)
				.HasForeignKey(i => i.FlightNoId);
		}
	}
}