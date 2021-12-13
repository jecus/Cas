using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightcargorecord")]
	public class FlightCargoRecordController : BaseController<FlightCargoRecordDTO>
	{
		public FlightCargoRecordController(DataContext context, ILogger<BaseController<FlightCargoRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
