using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class LifeLimitCategorieService : Repository<LifeLimitCategorieDTO>, ILifeLimitCategorieService
	{
		public LifeLimitCategorieService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<LifeLimitCategorieDTO>();
		}
	}
}