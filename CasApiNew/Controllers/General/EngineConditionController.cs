using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("enginecondition")]
	public class EngineConditionController : BaseController<EngineConditionDTO>
	{
		public EngineConditionController(DataContext context, ILogger<BaseController<EngineConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}
