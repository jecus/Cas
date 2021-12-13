using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("requestforquotationrecord")]
	public class RequestForQuotationRecordController : BaseController<RequestForQuotationRecordDTO>
	{
		public RequestForQuotationRecordController(DataContext context, ILogger<BaseController<RequestForQuotationRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

