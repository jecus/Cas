using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("maintenancedirective")]
	public class MaintenanceDirectiveController : BaseController<MaintenanceDirectiveDTO>
	{
		public MaintenanceDirectiveController(DataContext context, ILogger<BaseController<MaintenanceDirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
