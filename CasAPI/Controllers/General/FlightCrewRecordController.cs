using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightCrewRecord")]
	public class FlightCrewRecordController : BaseController<FlightCrewRecordDTO>
	{
		public FlightCrewRecordController(DataContext context, ILogger<BaseController<FlightCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
