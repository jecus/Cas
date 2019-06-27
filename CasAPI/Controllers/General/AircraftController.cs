using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("aircraft")]
	public class AircraftController : BaseController<AircraftDTO>
	{
		public AircraftController(DataContext context, ILogger<BaseController<AircraftDTO>> logger) : base(context, logger)
		{
		}
	}
}