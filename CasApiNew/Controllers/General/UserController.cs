using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("user")]
	public class UserController : BaseController<UserDTO>
	{
		public UserController(DataContext context, ILogger<BaseController<UserDTO>> logger) : base(context, logger)
		{

		}
	}
}

