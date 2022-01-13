using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("routineauditrecord")]
	public class RoutineAuditRecordController : BaseController<RoutineAuditRecordDTO>
	{
		public RoutineAuditRecordController(DataContext context, ILogger<BaseController<RoutineAuditRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}