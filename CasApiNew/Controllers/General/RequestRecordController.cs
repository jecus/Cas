using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("requestrecord")]
	public class RequestRecordController : BaseController<RequestRecordDTO>
	{
		public RequestRecordController(DataContext context, ILogger<BaseController<RequestRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
