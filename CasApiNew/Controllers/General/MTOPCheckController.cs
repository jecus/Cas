using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("mtopcheck")]
	public class MTOPCheckController : BaseController<MTOPCheckDTO>
	{
		public MTOPCheckController(DataContext context, ILogger<BaseController<MTOPCheckDTO>> logger) : base(context, logger)
		{

		}
	}
}

