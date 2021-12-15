using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flighttrackrecord")]
	public class FlightTrackRecordController : BaseController<FlightTrackRecordDTO>
	{
		public FlightTrackRecordController(DataContext context, ILogger<BaseController<FlightTrackRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
