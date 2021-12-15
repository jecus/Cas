using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("requestrecord")]
	public class RequestRecordController : BaseController<RequestRecordDTO>
	{
		public RequestRecordController(DataContext context, ILogger<BaseController<RequestRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
