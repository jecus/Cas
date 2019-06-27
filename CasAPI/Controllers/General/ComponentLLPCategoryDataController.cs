using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("componentLLPCategoryData")]
	public class ComponentLLPCategoryDataController : BaseController<ComponentLLPCategoryDataDTO>
	{
		public ComponentLLPCategoryDataController(DataContext context, ILogger<BaseController<ComponentLLPCategoryDataDTO>> logger) : base(context, logger)
		{

		}
	}
}

