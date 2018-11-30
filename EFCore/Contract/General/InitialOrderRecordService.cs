using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class InitialOrderRecordService : Repository<InitialOrderRecordDTO>, IInitialOrderRecordService
	{
		public InitialOrderRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<InitialOrderRecordDTO>();
		}
	}
}