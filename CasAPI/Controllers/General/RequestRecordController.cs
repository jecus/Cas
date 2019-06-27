using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("requestRecord")]
	public class RequestRecordController : BaseController<RequestRecordDTO>
	{
		public RequestRecordController(DataContext context, ILogger<BaseController<RequestRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
