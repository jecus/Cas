using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class RunUpService : Repository<RunUpDTO>, IRunUpService
	{
		public RunUpService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<RunUpDTO>();
		}
	}
}