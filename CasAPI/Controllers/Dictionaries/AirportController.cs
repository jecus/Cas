using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("airport")]
	public class AirportController : BaseController<AirportDTO>
	{
		public AirportController(DataContext context, ILogger<BaseController<AirportDTO>> logger) : base(context, logger)
		{
			
		}
	}
}