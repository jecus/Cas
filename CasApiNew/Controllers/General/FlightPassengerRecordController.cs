using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightpassengerrecord")]
	public class FlightPassengerRecordController : BaseController<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordController(DataContext context, ILogger<BaseController<FlightPassengerRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
