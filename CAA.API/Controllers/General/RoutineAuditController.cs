using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("routineaudit")]
	public class RoutineAuditController : BaseController<RoutineAuditDTO>
	{
		public RoutineAuditController(DataContext context, ILogger<BaseController<RoutineAuditDTO>> logger) : base(context, logger)
		{
		}
	}
}