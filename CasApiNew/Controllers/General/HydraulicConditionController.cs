using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("hydrauliccondition")]
	public class HydraulicConditionController : BaseController<HydraulicConditionDTO>
	{
		public HydraulicConditionController(DataContext context, ILogger<BaseController<HydraulicConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}

