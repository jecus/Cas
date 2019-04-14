using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class FlightNumMap : BaseMap<FlightNumDTO>
	{
		public FlightNumMap() : base()
		{
			ToTable("Dictionaries.FlightNum");

			Property(i => i.FlightNumber)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FlightNumber");
		}
	}
}