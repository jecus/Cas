using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("componentworkinregimeparam")]
	public class ComponentWorkInRegimeParamController : BaseController<ComponentWorkInRegimeParamDTO>
	{
		public ComponentWorkInRegimeParamController(DataContext context, ILogger<BaseController<ComponentWorkInRegimeParamDTO>> logger) : base(context, logger)
		{

		}
	}
}

