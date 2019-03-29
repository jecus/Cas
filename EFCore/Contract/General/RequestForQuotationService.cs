using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class RequestForQuotationService : Repository<RequestForQuotationDTO>, IRequestForQuotationService
	{
		public RequestForQuotationService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<RequestForQuotationDTO>();
		}
	}
}