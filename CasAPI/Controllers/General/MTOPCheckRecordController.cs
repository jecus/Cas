using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("MTOPCheckRecord")]
	public class MTOPCheckRecordController : BaseController<MTOPCheckRecordDTO>
	{
		public MTOPCheckRecordController(DataContext context, ILogger<BaseController<MTOPCheckRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
