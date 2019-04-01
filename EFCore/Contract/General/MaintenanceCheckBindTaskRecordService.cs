using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class MaintenanceCheckBindTaskRecordService : Repository<MaintenanceCheckBindTaskRecordDTO>, IMaintenanceCheckBindTaskRecordService
	{
		public MaintenanceCheckBindTaskRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<MaintenanceCheckBindTaskRecordDTO>();
		}
	}
}