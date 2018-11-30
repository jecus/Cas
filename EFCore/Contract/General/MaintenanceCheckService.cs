using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class MaintenanceCheckService : Repository<MaintenanceCheckDTO>, IMaintenanceCheckService
	{
		public MaintenanceCheckService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<MaintenanceCheckDTO>();
		}
	}
}