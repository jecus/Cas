using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("engineCondition")]
	public class EngineConditionController : BaseController<EngineConditionDTO>
	{
		public EngineConditionController(DataContext context, ILogger<BaseController<EngineConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}
