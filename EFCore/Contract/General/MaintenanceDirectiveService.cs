using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class MaintenanceDirectiveService : Repository<MaintenanceDirectiveDTO>, IMaintenanceDirectiveService
	{
		public MaintenanceDirectiveService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<MaintenanceDirectiveDTO>();
		}
	}
}