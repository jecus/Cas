using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightcrewrecord")]
	public class FlightCrewRecordController : BaseController<FlightCrewRecordDTO>
	{
		public FlightCrewRecordController(DataContext context, ILogger<BaseController<FlightCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
