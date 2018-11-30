using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class WorkOrderService : Repository<WorkOrderDTO>, IWorkOrderService
	{
		public WorkOrderService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<WorkOrderDTO>();
		}
	}
}