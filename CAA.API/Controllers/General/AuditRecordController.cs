using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("auditrecord")]
	public class AuditRecordController : BaseController<CAAAuditRecordDTO>
	{
		public AuditRecordController(DataContext context, ILogger<BaseController<CAAAuditRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}