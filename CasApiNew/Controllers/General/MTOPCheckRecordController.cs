using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("mtopcheckrecord")]
	public class MTOPCheckRecordController : BaseController<MTOPCheckRecordDTO>
	{
		public MTOPCheckRecordController(DataContext context, ILogger<BaseController<MTOPCheckRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
