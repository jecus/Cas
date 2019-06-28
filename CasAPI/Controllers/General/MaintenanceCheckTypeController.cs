using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("maintenancechecktype")]
	public class MaintenanceCheckTypeController : BaseController<MaintenanceCheckTypeDTO>
	{
		public MaintenanceCheckTypeController(DataContext context, ILogger<BaseController<MaintenanceCheckTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
