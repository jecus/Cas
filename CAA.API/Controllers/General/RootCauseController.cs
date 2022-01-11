using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("rootcause")]
	public class RootCauseController : BaseController<RootCauseDTO>
	{
		public RootCauseController(DataContext context, ILogger<BaseController<RootCauseDTO>> logger) : base(context, logger)
		{
		}
	}
}