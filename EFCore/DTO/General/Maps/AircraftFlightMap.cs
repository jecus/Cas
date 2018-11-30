using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class AircraftFlightMap : EntityTypeConfiguration<AircraftFlightDTO>
	{
		public AircraftFlightMap()
		{
			ToTable("dbo.AircraftFlights");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ATLBID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATLBID");

			Property(i => i.AircraftId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftId");

			Property(i => i.FlightNo)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNo");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.FlightDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightDate");

			Property(i => i.StationFrom)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationFrom");

			Property(i => i.StationTo)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationTo");

			Property(i => i.DelayTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DelayTime");

			Property(i => i.DelayReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DelayReasonId");

			Property(i => i.OutTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OutTime");

			Property(i => i.InTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("InTime");

			Property(i => i.TakeOffTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TakeOffTime");

			Property(i => i.LDGTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LDGTime");

			Property(i => i.NightTime)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NightTime");

			Property(i => i.CRSID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CRSID");

			Property(i => i.FileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileID");

			Property(i => i.Tanks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Tanks");

			Property(i => i.Fluids)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Fluids");

			Property(i => i.EnginesGeneralCondition)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EnginesGeneralCondition");

			Property(i => i.Highlight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Highlight");

			Property(i => i.Correct)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Correct");

			Property(i => i.Reference)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Reference");

			Property(i => i.Cycles)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cycles");

			Property(i => i.PageNo)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PageNo");

			Property(i => i.FlightType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightType");

			Property(i => i.LevelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Level");

			Property(i => i.Distance)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Distance");

			Property(i => i.DistanceMeasure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DistanceMeasure");

			Property(i => i.TakeOffWeight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TakeOffWeight");

			Property(i => i.AlignmentBefore)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AlignmentBefore");

			Property(i => i.AlignmentAfter)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AlignmentAfter");

			Property(i => i.FlightCategory)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightCategory");

			Property(i => i.AtlbRecordType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AtlbRecordType");

			Property(i => i.FlightAircraftCode)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightAircraftCode");

			Property(i => i.CancelReasonId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CancelReasonId");

			Property(i => i.StationFromId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationFromId");

			Property(i => i.StationToId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StationToId");

			Property(i => i.FlightNumberId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNumber");

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