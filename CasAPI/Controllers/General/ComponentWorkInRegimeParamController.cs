using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("componentworkinregimeparam")]
	public class ComponentWorkInRegimeParamController : BaseController<ComponentWorkInRegimeParamDTO>
	{
		public ComponentWorkInRegimeParamController(DataContext context, ILogger<BaseController<ComponentWorkInRegimeParamDTO>> logger) : base(context, logger)
		{

		}
	}
}

