using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flighttrackrecord")]
	public class FlightTrackRecordController : BaseController<FlightTrackRecordDTO>
	{
		public FlightTrackRecordController(DataContext context, ILogger<BaseController<FlightTrackRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
