using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("request")]
	public class RequestController : BaseController<RequestDTO>
	{
		public RequestController(DataContext context, ILogger<BaseController<RequestDTO>> logger) : base(context, logger)
		{

		}
	}
}
