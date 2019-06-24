using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LocationsTypeMap : BaseMap<LocationsTypeDTO>
	{
		public LocationsTypeMap() : base()
		{
			HasRequired(i => i.Department)
				.WithMany(i => i.LocationsTypeDtos)
				.HasForeignKey(i => i.DepartmentId);
		}
	}
}