using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class AirportCodeService : Repository<AirportCodeDTO>, IAirportCodeService
	{
		public AirportCodeService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AirportCodeDTO>();
		}
	}
}