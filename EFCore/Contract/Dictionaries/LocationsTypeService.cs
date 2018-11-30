using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class LocationsTypeService : Repository<LocationsTypeDTO>, ILocationsTypeService
	{
		public LocationsTypeService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<LocationsTypeDTO>();
		}
	}
}