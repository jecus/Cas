using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("aircraft")]
	public class AircraftController : BaseController<CAAAircraftDTO>
	{
		public AircraftController(DataContext context, ILogger<BaseController<CAAAircraftDTO>> logger) : base(context, logger)
		{
		}
	}
}