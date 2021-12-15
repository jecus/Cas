using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("eventcondition")]
	public class EventConditionController : BaseController<EventConditionDTO>
	{
		public EventConditionController(DataContext context, ILogger<BaseController<EventConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

