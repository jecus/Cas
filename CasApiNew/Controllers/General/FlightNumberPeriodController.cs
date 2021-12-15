using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightnumberperiod")]
	public class FlightNumberPeriodController : BaseController<FlightNumberPeriodDTO>
	{
		public FlightNumberPeriodController(DataContext context, ILogger<BaseController<FlightNumberPeriodDTO>> logger) : base(context, logger)
		{

		}
	}
}
