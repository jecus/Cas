using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("maintenancechecktype")]
	public class MaintenanceCheckTypeController : BaseController<MaintenanceCheckTypeDTO>
	{
		public MaintenanceCheckTypeController(DataContext context, ILogger<BaseController<MaintenanceCheckTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
