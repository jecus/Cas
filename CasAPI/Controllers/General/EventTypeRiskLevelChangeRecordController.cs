using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("eventTypeRiskLevelChangeRecord")]
	public class EventTypeRiskLevelChangeRecordController : BaseController<EventTypeRiskLevelChangeRecordDTO>
	{
		public EventTypeRiskLevelChangeRecordController(DataContext context, ILogger<BaseController<EventTypeRiskLevelChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
