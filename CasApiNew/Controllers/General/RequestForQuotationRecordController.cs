using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("requestforquotationrecord")]
	public class RequestForQuotationRecordController : BaseController<RequestForQuotationRecordDTO>
	{
		public RequestForQuotationRecordController(DataContext context, ILogger<BaseController<RequestForQuotationRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

