using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("componentdirective")]
	public class ComponentDirectiveController : BaseController<ComponentDirectiveDTO>
	{
		public ComponentDirectiveController(DataContext context, ILogger<BaseController<ComponentDirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}