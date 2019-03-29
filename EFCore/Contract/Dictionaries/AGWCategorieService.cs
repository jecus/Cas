using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class AGWCategorieService : Repository<AGWCategorieDTO>, IAGWCategorieService
	{
		public AGWCategorieService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AGWCategorieDTO>();
		}
	}
}