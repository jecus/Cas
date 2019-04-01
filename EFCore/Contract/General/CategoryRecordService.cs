using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class CategoryRecordService : Repository<CategoryRecordDTO>, ICategoryRecordService
	{
		public CategoryRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<CategoryRecordDTO>();
		}
	}
}