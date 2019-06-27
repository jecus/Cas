using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightNumberCrewRecord")]
	public class FlightNumberCrewRecordController : BaseController<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordController(DataContext context, ILogger<BaseController<FlightNumberCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
