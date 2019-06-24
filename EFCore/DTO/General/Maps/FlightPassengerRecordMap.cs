using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightPassengerRecordMap : BaseMap<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordMap() : base()
		{
			HasRequired(i => i.PassengerCategory)
				.WithMany(i => i.FlightPassengerRecordDtos)
				.HasForeignKey(i => i.PassengerCategoryId);
		}
	}
}