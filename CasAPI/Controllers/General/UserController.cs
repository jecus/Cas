using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("user")]
	public class UserController : BaseController<UserDTO>
	{
		public UserController(DataContext context, ILogger<BaseController<UserDTO>> logger) : base(context, logger)
		{

		}
	}
}

