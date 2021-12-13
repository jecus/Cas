using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("requestforquotation")]
	public class RequestForQuotationController : BaseController<RequestForQuotationDTO>
	{
		public RequestForQuotationController(DataContext context, ILogger<BaseController<RequestForQuotationDTO>> logger) : base(context, logger)
		{

		}
	}
}

