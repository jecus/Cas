using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("aircraft")]
	public class AircraftController : BaseController<AircraftDTO>
	{
		public AircraftController(DataContext context, ILogger<BaseController<AircraftDTO>> logger) : base(context, logger)
		{
		}
	}
}