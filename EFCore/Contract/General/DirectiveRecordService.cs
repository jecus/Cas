using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class DirectiveRecordService : Repository<DirectiveRecordDTO>, IDirectiveRecordService
	{
		public DirectiveRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<DirectiveRecordDTO>();
		}
	}
}