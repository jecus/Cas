using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workshop")]
	public class WorkShopController : BaseController<WorkShopDTO>
	{
		public WorkShopController(DataContext context, ILogger<BaseController<WorkShopDTO>> logger) : base(context, logger)
		{

		}
	}
}

