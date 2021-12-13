
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("componentllpcategorydata")]
	public class ComponentLLPCategoryDataController : BaseController<ComponentLLPCategoryDataDTO>
	{
		public ComponentLLPCategoryDataController(DataContext context, ILogger<BaseController<ComponentLLPCategoryDataDTO>> logger) : base(context, logger)
		{

		}
	}
}

