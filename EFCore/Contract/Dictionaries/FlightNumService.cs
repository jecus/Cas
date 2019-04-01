using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class FlightNumService : Repository<FlightNumDTO>, IFlightNumService
	{
		public FlightNumService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<FlightNumDTO>();
		}
	}
}