using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("maintenancecheck")]
	public class MaintenanceCheckController : BaseController<MaintenanceCheckDTO>
	{
		public MaintenanceCheckController(DataContext context, ILogger<BaseController<MaintenanceCheckDTO>> logger) : base(context, logger)
		{

		}
	}
}

