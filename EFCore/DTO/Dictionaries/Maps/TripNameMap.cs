using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class TripNameMap : BaseMap<TripNameDTO>
	{
		public TripNameMap() : base()
		{
			ToTable("Dictionaries.TripName");

			Property(i => i.TripName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TripName");
		}
	}
}