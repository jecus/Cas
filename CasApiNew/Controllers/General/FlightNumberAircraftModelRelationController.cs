using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightnumberaircraftmodelrelation")]
	public class FlightNumberAircraftModelRelationController : BaseController<FlightNumberAircraftModelRelationDTO>
	{
		public FlightNumberAircraftModelRelationController(DataContext context, ILogger<BaseController<FlightNumberAircraftModelRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
