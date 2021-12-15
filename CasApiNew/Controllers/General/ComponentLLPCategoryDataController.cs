using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("componentllpcategorydata")]
	public class ComponentLLPCategoryDataController : BaseController<ComponentLLPCategoryDataDTO>
	{
		public ComponentLLPCategoryDataController(DataContext context, ILogger<BaseController<ComponentLLPCategoryDataDTO>> logger) : base(context, logger)
		{

		}
	}
}

