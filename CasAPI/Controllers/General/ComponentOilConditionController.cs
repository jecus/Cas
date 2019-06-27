using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("componentOilCondition")]
	public class ComponentOilConditionController : BaseController<ComponentOilConditionDTO>
	{
		public ComponentOilConditionController(DataContext context, ILogger<BaseController<ComponentOilConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

