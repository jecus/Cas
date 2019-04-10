using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class AirportMap : BaseMap<AirportDTO>
	{
		public AirportMap() : base()
		{
			ToTable("Dictionaries.Airports");

			Property(i => i.ShortName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");

			Property(i => i.FullName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.LocalityId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Locality");

			Property(i => i.Altitude)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Altitude");

			Property(i => i.TimeBeginning)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeBeginning");

			Property(i => i.TimeEnd)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TimeEnd");

		}
	}
}