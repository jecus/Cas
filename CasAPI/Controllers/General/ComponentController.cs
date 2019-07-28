using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("component")]
	public class ComponentController : BaseController<ComponentDTO>
	{
		public ComponentController(DataContext context, ILogger<BaseController<ComponentDTO>> logger) : base(context, logger)
		{

		}
	}
}