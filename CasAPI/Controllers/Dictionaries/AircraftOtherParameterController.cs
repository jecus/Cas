using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route(" aircraftotherparameter")]
	public class AircraftOtherParameterController : BaseController<AircraftOtherParameterDTO>
	{
		public AircraftOtherParameterController(DataContext context, ILogger<BaseController<AircraftOtherParameterDTO>> logger) : base(context, logger)
		{
			
		}
	}
}