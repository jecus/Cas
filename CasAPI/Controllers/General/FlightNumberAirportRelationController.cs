using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightnumberairportrelation")]
	public class FlightNumberAirportRelationController : BaseController<FlightNumberAirportRelationDTO>
	{
		public FlightNumberAirportRelationController(DataContext context, ILogger<BaseController<FlightNumberAirportRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
