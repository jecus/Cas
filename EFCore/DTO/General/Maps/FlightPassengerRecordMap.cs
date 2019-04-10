using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightPassengerRecordMap : BaseMap<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordMap() : base()
		{
			ToTable("dbo.FlightPassengerRecords");

			Property(i => i.FlightId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightId");

			Property(i => i.PassengerCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PassengerCategory");

			Property(i => i.CountEconomy)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CountEconomy");

			Property(i => i.CountBusiness)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CountBusiness");

			Property(i => i.CountFirst)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CountFirst");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			HasRequired(i => i.PassengerCategory)
				.WithMany(i => i.FlightPassengerRecordDtos)
				.HasForeignKey(i => i.PassengerCategoryId);
		}
	}
}