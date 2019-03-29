using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class FlightCargoRecordService : Repository<FlightCargoRecordDTO>, IFlightCargoRecordService
	{
		public FlightCargoRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightCargoRecordDTO>();
		}
	}
}