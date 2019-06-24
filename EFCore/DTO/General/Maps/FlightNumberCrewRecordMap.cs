using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberCrewRecordMap : BaseMap<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordMap() : base()
		{
			HasRequired(i => i.FlightNumber)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.FlightNumberId);

			HasRequired(i => i.Specialization)
				.WithMany(i => i.FlightNumberCrewRecordDtos)
				.HasForeignKey(i => i.SpecializationId);
		}
	}
}