using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class AirportService : Repository<AirportDTO>, IAirportService
	{
		public AirportService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AirportDTO>();
		}
	}
}