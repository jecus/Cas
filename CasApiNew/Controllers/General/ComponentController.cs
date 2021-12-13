using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("component")]
	public class ComponentController : BaseController<ComponentDTO>
	{
		public ComponentController(DataContext context, ILogger<BaseController<ComponentDTO>> logger) : base(context, logger)
		{

		}
	}
}