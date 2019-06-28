using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flighttrackrecord")]
	public class FlightTrackRecordController : BaseController<FlightTrackRecordDTO>
	{
		public FlightTrackRecordController(DataContext context, ILogger<BaseController<FlightTrackRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
