using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("event")]
	public class EventController : BaseController<EventDTO>
	{
		public EventController(DataContext context, ILogger<BaseController<EventDTO>> logger) : base(context, logger)
		{

		}
	}
}

