using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class CRSService : Repository<CertificateOfReleaseToServiceDTO>, ICRSService
	{
		public CRSService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<CertificateOfReleaseToServiceDTO>();
		}
	}
}