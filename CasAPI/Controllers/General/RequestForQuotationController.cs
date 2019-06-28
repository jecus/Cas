using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("requestforquotation")]
	public class RequestForQuotationController : BaseController<RequestForQuotationDTO>
	{
		public RequestForQuotationController(DataContext context, ILogger<BaseController<RequestForQuotationDTO>> logger) : base(context, logger)
		{

		}
	}
}

