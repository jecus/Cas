using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class FlightNumberAirportRelationService : Repository<FlightNumberAirportRelationDTO>, IFlightNumberAirportRelationService
	{
		public FlightNumberAirportRelationService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightNumberAirportRelationDTO>();
		}
	}
}