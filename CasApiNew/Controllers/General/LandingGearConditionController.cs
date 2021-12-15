using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("landinggearcondition")]
	public class LandingGearConditionController : BaseController<LandingGearConditionDTO>
	{
		public LandingGearConditionController(DataContext context, ILogger<BaseController<LandingGearConditionDTO>> logger) : base(context, logger)
		{

		}
	}
}
