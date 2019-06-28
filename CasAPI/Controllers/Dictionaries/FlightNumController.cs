using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("flightnum")]
	public class FlightNumController : BaseController<FlightNumDTO>
	{
		public FlightNumController(DataContext context, ILogger<BaseController<FlightNumDTO>> logger) : base(context, logger)
		{
			
		}
	}
}