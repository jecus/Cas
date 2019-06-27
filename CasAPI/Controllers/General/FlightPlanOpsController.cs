using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightPlanOps")]
	public class FlightPlanOpsController : BaseController<FlightPlanOpsDTO>
	{
		public FlightPlanOpsController(DataContext context, ILogger<BaseController<FlightPlanOpsDTO>> logger) : base(context, logger)
		{

		}
	}
}

