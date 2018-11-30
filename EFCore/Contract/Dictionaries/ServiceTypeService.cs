using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class ServiceTypeService : Repository<ServiceTypeDTO>, IServiceTypeService
	{
		public ServiceTypeService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<ServiceTypeDTO>();
		}
	}
}