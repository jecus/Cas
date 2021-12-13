using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("eventcondition")]
	public class EventConditionController : BaseController<EventConditionDTO>
	{
		public EventConditionController(DataContext context, ILogger<BaseController<EventConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

