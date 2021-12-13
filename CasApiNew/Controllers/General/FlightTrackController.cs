using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flighttrack")]
	public class FlightTrackController : BaseController<FlightTrackDTO>
	{
		public FlightTrackController(DataContext context, ILogger<BaseController<FlightTrackDTO>> logger) : base(context, logger)
		{

		}
	}
}
