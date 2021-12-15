using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightplanops")]
	public class FlightPlanOpsController : BaseController<FlightPlanOpsDTO>
	{
		public FlightPlanOpsController(DataContext context, ILogger<BaseController<FlightPlanOpsDTO>> logger) : base(context, logger)
		{

		}
	}
}

