using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class FlightPassengerRecordMap : EntityTypeConfiguration<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordMap()
		{
			ToTable("dbo.FlightPassengerRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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