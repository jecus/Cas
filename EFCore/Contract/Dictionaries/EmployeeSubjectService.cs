using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class EmployeeSubjectService : Repository<EmployeeSubjectDTO>, IEmployeeSubjectService
	{
		public EmployeeSubjectService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<EmployeeSubjectDTO>();
		}
	}
}