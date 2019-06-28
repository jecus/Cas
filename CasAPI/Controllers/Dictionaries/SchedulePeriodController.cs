using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("scheduleperiod")]
	public class SchedulePeriodController : BaseController<SchedulePeriodDTO>
	{
		public SchedulePeriodController(DataContext context, ILogger<BaseController<SchedulePeriodDTO>> logger) : base(context, logger)
		{
			
		}
	}
}