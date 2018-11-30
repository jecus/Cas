using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class AircraftWorkerCategoryService : Repository<AircraftWorkerCategoryDTO>, IAircraftWorkerCategoryService
	{
		public AircraftWorkerCategoryService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AircraftWorkerCategoryDTO>();
		}
	}
}