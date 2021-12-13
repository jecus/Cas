
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("componentworkinregimeparam")]
	public class ComponentWorkInRegimeParamController : BaseController<ComponentWorkInRegimeParamDTO>
	{
		public ComponentWorkInRegimeParamController(DataContext context, ILogger<BaseController<ComponentWorkInRegimeParamDTO>> logger) : base(context, logger)
		{

		}
	}
}

