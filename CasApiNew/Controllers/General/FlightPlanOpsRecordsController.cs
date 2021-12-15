using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightplanopsrecords")]
	public class FlightPlanOpsRecordsController : BaseController<FlightPlanOpsRecordsDTO>
	{
		public FlightPlanOpsRecordsController(DataContext context, ILogger<BaseController<FlightPlanOpsRecordsDTO>> logger) : base(context, logger)
		{

		}
	}
}
