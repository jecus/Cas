using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("directive")]
	public class DirectiveController : BaseController<DirectiveDTO>
	{
		public DirectiveController(DataContext context, ILogger<BaseController<DirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
