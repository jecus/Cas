using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("user")]
	public class UserController : BaseController<CAAUserDTO>
	{
		public UserController(DataContext context, ILogger<BaseController<CAAUserDTO>> logger) : base(context, logger)
		{

		}
	}
}

