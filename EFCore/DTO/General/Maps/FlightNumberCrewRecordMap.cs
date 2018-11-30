using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberCrewRecordMap : EntityTypeConfiguration<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordMap()
		{
			ToTable("dbo.FlightNumberCrewRecords");

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

			Property(i => i.SpecializationId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecializationId");

			Property(i => i.Count)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Count");

			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.Specialization)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationId);
		}
	}
}