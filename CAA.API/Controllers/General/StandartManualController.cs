using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("standartmanual")]
	public class StandartManualController : BaseController<StandartManualDTO>
	{
		public StandartManualController(DataContext context, ILogger<BaseController<StandartManualDTO>> logger) : base(context, logger)
		{
		}
	}
}