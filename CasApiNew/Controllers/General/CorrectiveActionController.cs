using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("correctiveaction")]
	public class CorrectiveActionController : BaseController<CorrectiveActionDTO>
	{
		public CorrectiveActionController(DataContext context, ILogger<BaseController<CorrectiveActionDTO>> logger) : base(context, logger)
		{

		}
	}
}
