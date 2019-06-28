using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightnumberperiod")]
	public class FlightNumberPeriodController : BaseController<FlightNumberPeriodDTO>
	{
		public FlightNumberPeriodController(DataContext context, ILogger<BaseController<FlightNumberPeriodDTO>> logger) : base(context, logger)
		{

		}
	}
}
