using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("correctiveaction")]
	public class CorrectiveActionController : BaseController<CorrectiveActionDTO>
	{
		public CorrectiveActionController(DataContext context, ILogger<BaseController<CorrectiveActionDTO>> logger) : base(context, logger)
		{

		}
	}
}
