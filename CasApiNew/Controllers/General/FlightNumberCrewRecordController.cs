using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightnumbercrewrecord")]
	public class FlightNumberCrewRecordController : BaseController<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordController(DataContext context, ILogger<BaseController<FlightNumberCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
