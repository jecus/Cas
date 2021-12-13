using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("eventtyperisklevelchangerecord")]
	public class EventTypeRiskLevelChangeRecordController : BaseController<EventTypeRiskLevelChangeRecordDTO>
	{
		public EventTypeRiskLevelChangeRecordController(DataContext context, ILogger<BaseController<EventTypeRiskLevelChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
