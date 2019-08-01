using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("enginetimeinregime")]
	public class EngineTimeInRegimeController : BaseController<EngineTimeInRegimeDTO>
	{
		public EngineTimeInRegimeController(DataContext context, ILogger<BaseController<EngineTimeInRegimeDTO>> logger) : base(context, logger)
		{

		}
	}
}
