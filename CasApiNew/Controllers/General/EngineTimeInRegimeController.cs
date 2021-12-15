using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("enginetimeinregime")]
	public class EngineTimeInRegimeController : BaseController<EngineTimeInRegimeDTO>
	{
		public EngineTimeInRegimeController(DataContext context, ILogger<BaseController<EngineTimeInRegimeDTO>> logger) : base(context, logger)
		{

		}
	}
}
