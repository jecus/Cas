using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightCrewRecordMap : BaseMap<FlightCrewRecordDTO>
	{
		public FlightCrewRecordMap() : base()
		{
			HasRequired(i => i.Specialist)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecialistID);

			HasRequired(i => i.Specialization)
				.WithMany(i => i.FlightCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationID);
		}
	}
}