using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("request")]
	public class RequestController : BaseController<RequestDTO>
	{
		public RequestController(DataContext context, ILogger<BaseController<RequestDTO>> logger) : base(context, logger)
		{

		}
	}
}
