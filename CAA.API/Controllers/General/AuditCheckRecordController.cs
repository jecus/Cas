using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("auditcheckrecord")]
	public class AuditCheckRecordController : BaseController<AuditCheckRecordDTO>
	{
		public AuditCheckRecordController(DataContext context, ILogger<BaseController<AuditCheckRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}