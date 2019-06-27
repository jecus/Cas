using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("flightNumber")]
	public class FlightNumberController : BaseController<FlightNumberDTO>
	{
		public FlightNumberController(DataContext context, ILogger<BaseController<FlightNumberDTO>> logger) : base(context, logger)
		{

		}
	}
}
