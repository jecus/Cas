using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("scheduleperiod")]
	public class SchedulePeriodController : BaseDictionaryController<SchedulePeriodDTO>
	{
        public SchedulePeriodController(DataContext context, ILogger<BaseController<SchedulePeriodDTO>> logger) : base(context, logger)
		{
			
		}
    }
}