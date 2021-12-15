using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightpassengerrecord")]
	public class FlightPassengerRecordController : BaseController<FlightPassengerRecordDTO>
	{
		public FlightPassengerRecordController(DataContext context, ILogger<BaseController<FlightPassengerRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
