using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class EngineTimeInRegimeService : Repository<EngineTimeInRegimeDTO>, IEngineTimeInRegimeService
	{
		public EngineTimeInRegimeService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<EngineTimeInRegimeDTO>();
		}
	}
}