using System.Configuration;
using EFCore.DTO;
using EFCore.DTO.Dictionaries;
using EFCore.Repository;

namespace EFCore.Contract.Dictionaries
{
	public class EventCategorieService : Repository<EventCategorieDTO>, IEventCategorieService
	{
		public EventCategorieService()
		{
			var connection = Helper.Helper.GetConnectionString();
			_context = new DataContext(connection);
			_dbset = _context.Set<EventCategorieDTO>();
		}
	}
}