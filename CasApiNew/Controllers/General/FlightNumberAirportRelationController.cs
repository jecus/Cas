using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightnumberairportrelation")]
	public class FlightNumberAirportRelationController : BaseController<FlightNumberAirportRelationDTO>
	{
		public FlightNumberAirportRelationController(DataContext context, ILogger<BaseController<FlightNumberAirportRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
