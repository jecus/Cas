using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("user")]
	public class UserController : BaseController<UserDTO>
	{
		public UserController(DataContext context, ILogger<BaseController<UserDTO>> logger) : base(context, logger)
		{

		}
	}
}

