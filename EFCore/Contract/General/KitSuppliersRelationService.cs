using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class KitSuppliersRelationService : Repository<KitSuppliersRelationDTO>, IKitSuppliersRelationService
	{
		public KitSuppliersRelationService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<KitSuppliersRelationDTO>();
		}
	}
}