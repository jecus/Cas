using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightcrewrecord")]
	public class FlightCrewRecordController : BaseController<FlightCrewRecordDTO>
	{
		public FlightCrewRecordController(DataContext context, ILogger<BaseController<FlightCrewRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
