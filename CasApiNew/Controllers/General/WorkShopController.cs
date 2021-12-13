using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workshop")]
	public class WorkShopController : BaseController<WorkShopDTO>
	{
		public WorkShopController(DataContext context, ILogger<BaseController<WorkShopDTO>> logger) : base(context, logger)
		{

		}
	}
}

