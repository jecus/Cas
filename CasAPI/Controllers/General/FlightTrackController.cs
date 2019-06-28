using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flighttrack")]
	public class FlightTrackController : BaseController<FlightTrackDTO>
	{
		public FlightTrackController(DataContext context, ILogger<BaseController<FlightTrackDTO>> logger) : base(context, logger)
		{

		}
	}
}
