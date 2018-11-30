using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class FlightNumberAircraftModelRelationService : Repository<FlightNumberAircraftModelRelationDTO>, IFlightNumberAircraftModelRelationService
	{
		public FlightNumberAircraftModelRelationService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightNumberAircraftModelRelationDTO>();
		}
	}
}