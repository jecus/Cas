using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("aircraftotherparameter")]
	public class AircraftOtherParameterController : BaseDictionaryController<AircraftOtherParameterDTO>
	{

        public AircraftOtherParameterController(DataContext context, ILogger<BaseController<AircraftOtherParameterDTO>> logger) : base(context, logger)
		{
			
		}
    }
}