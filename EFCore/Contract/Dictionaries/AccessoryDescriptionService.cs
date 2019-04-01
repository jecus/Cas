using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class AccessoryDescriptionService : Repository<AccessoryDescriptionDTO>, IAccessoryDescriptionService
	{
		public AccessoryDescriptionService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<AccessoryDescriptionDTO>();
		}

	}
}