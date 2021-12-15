using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightcargorecord")]
	public class FlightCargoRecordController : BaseController<FlightCargoRecordDTO>
	{
		public FlightCargoRecordController(DataContext context, ILogger<BaseController<FlightCargoRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
