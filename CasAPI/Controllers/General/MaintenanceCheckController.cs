using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("maintenanceCheck")]
	public class MaintenanceCheckController : BaseController<MaintenanceCheckDTO>
	{
		public MaintenanceCheckController(DataContext context, ILogger<BaseController<MaintenanceCheckDTO>> logger) : base(context, logger)
		{

		}
	}
}

