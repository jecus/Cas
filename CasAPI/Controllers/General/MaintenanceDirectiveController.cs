using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("maintenanceDirective")]
	public class MaintenanceDirectiveController : BaseController<MaintenanceDirectiveDTO>
	{
		public MaintenanceDirectiveController(DataContext context, ILogger<BaseController<MaintenanceDirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
