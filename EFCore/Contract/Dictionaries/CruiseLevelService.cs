using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class CruiseLevelService : Repository<CruiseLevelDTO>, ICruiseLevelService
	{
		public CruiseLevelService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<CruiseLevelDTO>();
		}
	}
}