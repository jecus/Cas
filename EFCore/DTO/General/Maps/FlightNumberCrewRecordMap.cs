using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberCrewRecordMap : BaseMap<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordMap() : base()
		{
			ToTable("dbo.FlightNumberCrewRecords");

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