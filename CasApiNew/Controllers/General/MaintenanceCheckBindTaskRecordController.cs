using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("maintenancecheckbindtaskrecord")]
	public class MaintenanceCheckBindTaskRecordController : BaseController<MaintenanceCheckBindTaskRecordDTO>
	{
		public MaintenanceCheckBindTaskRecordController(DataContext context, ILogger<BaseController<MaintenanceCheckBindTaskRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}