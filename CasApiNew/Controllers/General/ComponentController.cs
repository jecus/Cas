using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("component")]
	public class ComponentController : BaseController<ComponentDTO>
	{
		public ComponentController(DataContext context, ILogger<BaseController<ComponentDTO>> logger) : base(context, logger)
		{

		}
	}
}