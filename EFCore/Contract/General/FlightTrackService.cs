using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class FlightTrackService : Repository<FlightTrackDTO>, IFlightTrackService
	{
		public FlightTrackService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightTrackDTO>();
		}
	}
}