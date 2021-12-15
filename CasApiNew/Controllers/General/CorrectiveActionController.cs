using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("correctiveaction")]
	public class CorrectiveActionController : BaseController<CorrectiveActionDTO>
	{
		public CorrectiveActionController(DataContext context, ILogger<BaseController<CorrectiveActionDTO>> logger) : base(context, logger)
		{

		}
	}
}
