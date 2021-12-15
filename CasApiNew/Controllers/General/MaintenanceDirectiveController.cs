using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("maintenancedirective")]
	public class MaintenanceDirectiveController : BaseController<MaintenanceDirectiveDTO>
	{
		public MaintenanceDirectiveController(DataContext context, ILogger<BaseController<MaintenanceDirectiveDTO>> logger) : base(context, logger)
		{

		}
	}
}
