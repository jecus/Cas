using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class InitialOrderService : Repository<InitialOrderDTO>, IInitialOrderService
	{
		public InitialOrderService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<InitialOrderDTO>();
		}
	}
}