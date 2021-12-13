using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightnumbercrewrecord")]
	public class FlightNumberCrewRecordController : BaseController<FlightNumberCrewRecordDTO>
	{
		public FlightNumberCrewRecordController(DataContext context, ILogger<BaseController<FlightNumberCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
