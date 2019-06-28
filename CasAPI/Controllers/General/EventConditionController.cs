using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("eventcondition")]
	public class EventConditionController : BaseController<EventConditionDTO>
	{
		public EventConditionController(DataContext context, ILogger<BaseController<EventConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

