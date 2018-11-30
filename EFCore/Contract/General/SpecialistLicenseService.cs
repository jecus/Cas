using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class SpecialistLicenseService : Repository<SpecialistLicenseDTO>, ISpecialistLicenseService
	{
		public SpecialistLicenseService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<SpecialistLicenseDTO>();
		}
	}
}