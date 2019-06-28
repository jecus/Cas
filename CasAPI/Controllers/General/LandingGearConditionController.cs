using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("landinggearcondition")]
	public class LandingGearConditionController : BaseController<LandingGearConditionDTO>
	{
		public LandingGearConditionController(DataContext context, ILogger<BaseController<LandingGearConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}
