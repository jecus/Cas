using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("eventCategorie")]
	public class EventCategorieController : BaseController<EventCategorieDTO>
	{
		public EventCategorieController(DataContext context, ILogger<BaseController<EventCategorieDTO>> logger) : base(context, logger)
		{
			
		}
	}
}