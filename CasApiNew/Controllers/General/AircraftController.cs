using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("aircraft")]
	public class AircraftController : BaseController<AircraftDTO>
	{
		public AircraftController(DataContext context, ILogger<BaseController<AircraftDTO>> logger) : base(context, logger)
		{
		}
	}
}