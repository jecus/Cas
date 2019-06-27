using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("componentDirective")]
	public class ComponentDirectiveController : BaseController<ComponentDirectiveDTO>
	{
		public ComponentDirectiveController(DataContext context, ILogger<BaseController<ComponentDirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}