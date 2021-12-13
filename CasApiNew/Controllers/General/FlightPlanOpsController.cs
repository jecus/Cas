using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightplanops")]
	public class FlightPlanOpsController : BaseController<FlightPlanOpsDTO>
	{
		public FlightPlanOpsController(DataContext context, ILogger<BaseController<FlightPlanOpsDTO>> logger) : base(context, logger)
		{

		}
	}
}

