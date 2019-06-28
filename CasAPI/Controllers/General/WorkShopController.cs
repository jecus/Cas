using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("workshop")]
	public class WorkShopController : BaseController<WorkShopDTO>
	{
		public WorkShopController(DataContext context, ILogger<BaseController<WorkShopDTO>> logger) : base(context, logger)
		{

		}
	}
}

