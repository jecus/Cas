using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("aircraftotherparameter")]
	public class AircraftOtherParameterController : BaseDictionaryController<CAAAircraftOtherParameterDTO>
	{

        public AircraftOtherParameterController(DataContext context, ILogger<BaseController<CAAAircraftOtherParameterDTO>> logger) : base(context, logger)
		{
			
		}
    }
}