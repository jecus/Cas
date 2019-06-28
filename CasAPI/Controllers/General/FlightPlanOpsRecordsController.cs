using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightplanopsrecords")]
	public class FlightPlanOpsRecordsController : BaseController<FlightPlanOpsRecordsDTO>
	{
		public FlightPlanOpsRecordsController(DataContext context, ILogger<BaseController<FlightPlanOpsRecordsDTO>> logger) : base(context, logger)
		{

		}
	}
}
