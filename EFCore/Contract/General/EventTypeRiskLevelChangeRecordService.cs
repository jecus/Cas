using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.General;
using EFCore.Repository;

namespace EFCore.Contract.General
{
	public class EventTypeRiskLevelChangeRecordService : Repository<EventTypeRiskLevelChangeRecordDTO>, IEventTypeRiskLevelChangeRecordService
	{
		public EventTypeRiskLevelChangeRecordService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<EventTypeRiskLevelChangeRecordDTO>();
		}
	}
}