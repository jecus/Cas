using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("requestforquotation")]
	public class RequestForQuotationController : BaseController<RequestForQuotationDTO>
	{
		public RequestForQuotationController(DataContext context, ILogger<BaseController<RequestForQuotationDTO>> logger) : base(context, logger)
		{

		}
	}
}

