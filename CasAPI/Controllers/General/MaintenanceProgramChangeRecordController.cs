using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("maintenanceProgramChangeRecord")]
	public class MaintenanceProgramChangeRecordController : BaseController<MaintenanceProgramChangeRecordDTO>
	{
		public MaintenanceProgramChangeRecordController(DataContext context, ILogger<BaseController<MaintenanceProgramChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
