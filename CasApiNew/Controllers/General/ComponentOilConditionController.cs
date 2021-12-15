using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("componentoilcondition")]
	public class ComponentOilConditionController : BaseController<ComponentOilConditionDTO>
	{
		public ComponentOilConditionController(DataContext context, ILogger<BaseController<ComponentOilConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

