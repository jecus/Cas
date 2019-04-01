using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class JobCardTaskService : Repository<JobCardTaskDTO>, IJobCardTaskService
	{
		public JobCardTaskService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<JobCardTaskDTO>();
		}
	}
}