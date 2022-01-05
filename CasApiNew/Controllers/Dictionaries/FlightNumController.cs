using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("flightnum")]
	public class FlightNumController : BaseDictionaryController<FlightNumDTO>
	{
        public FlightNumController(DataContext context, ILogger<BaseController<FlightNumDTO>> logger) : base(context, logger)
		{
			
		}
    }
}