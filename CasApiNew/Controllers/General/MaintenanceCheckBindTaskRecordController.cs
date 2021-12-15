using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("maintenancecheckbindtaskrecord")]
	public class MaintenanceCheckBindTaskRecordController : BaseController<MaintenanceCheckBindTaskRecordDTO>
	{
		public MaintenanceCheckBindTaskRecordController(DataContext context, ILogger<BaseController<MaintenanceCheckBindTaskRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}