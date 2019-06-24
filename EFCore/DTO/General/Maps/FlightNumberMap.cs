using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class FlightNumberMap : BaseMap<FlightNumberDTO>
	{
		public FlightNumberMap() : base()
		{
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