using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class AircraftOtherParameterService : Repository<AircraftOtherParameterDTO>, IAircraftOtherParameterService
	{
		public AircraftOtherParameterService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AircraftOtherParameterDTO>();
		}
	}
}