using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class SpecialistCAAService : Repository<SpecialistCAADTO>, ISpecialistCAAService
	{
		public SpecialistCAAService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<SpecialistCAADTO>();
		}
	}
}