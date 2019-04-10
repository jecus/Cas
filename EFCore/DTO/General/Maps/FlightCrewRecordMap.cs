using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightCrewRecordMap : BaseMap<FlightCrewRecordDTO>
	{
		public FlightCrewRecordMap() : base()
		{
			ToTable("dbo.FlightCrews");

			Property(i => i.FlightID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightID");

			Property(i => i.SpecialistID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistID");

			Property(i => i.SpecializationID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecializationID");

			Property(i => i.IDNo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IDNo");

			Property(i => i.Limitations)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Limitations");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			HasRequired(i => i.Specialist)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecialistID);

			HasRequired(i => i.Specialization)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationID);
		}
	}
}