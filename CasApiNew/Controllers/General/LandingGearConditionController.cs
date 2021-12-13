using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("landinggearcondition")]
	public class LandingGearConditionController : BaseController<LandingGearConditionDTO>
	{
		public LandingGearConditionController(DataContext context, ILogger<BaseController<LandingGearConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}
