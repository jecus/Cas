using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class FlightPlanOpsRecordsService : Repository<FlightPlanOpsRecordsDTO>, IFlightPlanOpsRecordsService
	{
		public FlightPlanOpsRecordsService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightPlanOpsRecordsDTO>();
		}
	}
}