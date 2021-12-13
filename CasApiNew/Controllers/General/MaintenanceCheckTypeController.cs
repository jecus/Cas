using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("maintenancechecktype")]
	public class MaintenanceCheckTypeController : BaseController<MaintenanceCheckTypeDTO>
	{
		public MaintenanceCheckTypeController(DataContext context, ILogger<BaseController<MaintenanceCheckTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
