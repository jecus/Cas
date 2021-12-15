using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("directive")]
	public class DirectiveController : BaseController<DirectiveDTO>
	{
		public DirectiveController(DataContext context, ILogger<BaseController<DirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
