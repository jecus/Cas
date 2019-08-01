using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("directive")]
	public class DirectiveController : BaseController<DirectiveDTO>
	{
		public DirectiveController(DataContext context, ILogger<BaseController<DirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
