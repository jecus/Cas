using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("maintenancecheck")]
	public class MaintenanceCheckController : BaseController<MaintenanceCheckDTO>
	{
		public MaintenanceCheckController(DataContext context, ILogger<BaseController<MaintenanceCheckDTO>> logger) : base(context, logger)
		{

		}
	}
}

