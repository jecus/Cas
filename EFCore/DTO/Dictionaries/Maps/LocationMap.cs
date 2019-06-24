using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LocationMap : BaseMap<LocationDTO>
	{
		public LocationMap() : base()
		{
			#region relation

			HasRequired(i => i.LocationsType)
				.WithMany(i => i.LocationDtos)
				.HasForeignKey(i => i.LocationsTypeId);

			#endregion

		}
	}
}