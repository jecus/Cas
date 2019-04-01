using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class SchedulePeriodService : Repository<SchedulePeriodDTO>, ISchedulePeriodService
	{
		public SchedulePeriodService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<SchedulePeriodDTO>();
		}
	}
}