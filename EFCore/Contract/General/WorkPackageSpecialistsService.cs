using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class WorkPackageSpecialistsService : Repository<WorkPackageSpecialistsDTO>, IWorkPackageSpecialistsService
	{
		public WorkPackageSpecialistsService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<WorkPackageSpecialistsDTO>();
		}
	}
}