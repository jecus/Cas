using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("event")]
	public class EventController : BaseController<EventDTO>
	{
		public EventController(DataContext context, ILogger<BaseController<EventDTO>> logger) : base(context, logger)
		{

		}
	}
}

