using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class DepartmentService : Repository<DepartmentDTO>, IDepartmentService
	{
		public DepartmentService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<DepartmentDTO>();
		}
	}
}