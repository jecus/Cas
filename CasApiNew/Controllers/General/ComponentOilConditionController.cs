
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("componentoilcondition")]
	public class ComponentOilConditionController : BaseController<ComponentOilConditionDTO>
	{
		public ComponentOilConditionController(DataContext context, ILogger<BaseController<ComponentOilConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

