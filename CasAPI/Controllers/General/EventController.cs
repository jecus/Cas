using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("event")]
	public class EventController : BaseController<EventDTO>
	{
		public EventController(DataContext context, ILogger<BaseController<EventDTO>> logger) : base(context, logger)
		{

		}
	}
}

