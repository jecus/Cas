using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("aircraftFlight")]
	public class AircraftFlightController : BaseController<AircraftFlightDTO>
	{
		public AircraftFlightController(DataContext context, ILogger<BaseController<AircraftFlightDTO>> logger) : base(context, logger)
		{
			
		}
	}
}