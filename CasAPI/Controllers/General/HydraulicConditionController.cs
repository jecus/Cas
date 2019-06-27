using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("hydraulicCondition")]
	public class HydraulicConditionController : BaseController<HydraulicConditionDTO>
	{
		public HydraulicConditionController(DataContext context, ILogger<BaseController<HydraulicConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

