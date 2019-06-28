using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("nonroutinejob")]
	public class NonRoutineJobController : BaseController<NonRoutineJobDTO>
	{
		public NonRoutineJobController(DataContext context, ILogger<BaseController<NonRoutineJobDTO>> logger) : base(context, logger)
		{
			
		}
	}
}