using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightnumberaircraftmodelrelation")]
	public class FlightNumberAircraftModelRelationController : BaseController<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationController(DataContext context, ILogger<BaseController<FlightNumberAircraftModelRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
