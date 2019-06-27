using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightNumberAircraftModelRelation")]
	public class FlightNumberAircraftModelRelationController : BaseController<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationController(DataContext context, ILogger<BaseController<FlightNumberAircraftModelRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
