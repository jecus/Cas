using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("maintenancecheckbindtaskrecord")]
	public class MaintenanceCheckBindTaskRecordController : BaseController<MaintenanceCheckBindTaskRecordDTO>
	{
		public MaintenanceCheckBindTaskRecordController(DataContext context, ILogger<BaseController<MaintenanceCheckBindTaskRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}