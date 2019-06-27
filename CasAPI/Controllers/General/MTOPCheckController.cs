using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("MTOPCheck")]
	public class MTOPCheckController : BaseController<MTOPCheckDTO>
	{
		public MTOPCheckController(DataContext context, ILogger<BaseController<MTOPCheckDTO>> logger) : base(context, logger)
		{

		}
	}
}

