using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightPassengerRecord")]
	public class FlightPassengerRecordController : BaseController<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordController(DataContext context, ILogger<BaseController<FlightPassengerRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
