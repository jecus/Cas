using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("request")]
	public class RequestController : BaseController<RequestDTO>
	{
		public RequestController(DataContext context, ILogger<BaseController<RequestDTO>> logger) : base(context, logger)
		{

		}
	}
}
