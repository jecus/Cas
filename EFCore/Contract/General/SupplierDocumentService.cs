using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class SupplierDocumentService : Repository<SupplierDocumentDTO>, ISupplierDocumentService
	{
		public SupplierDocumentService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<SupplierDocumentDTO>();
		}
	}
}