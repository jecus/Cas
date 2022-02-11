using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("auditpelrecord")]
	public class AuditPelRecordController : BaseController<AuditPelRecordDTO>
	{
		public AuditPelRecordController(DataContext context, ILogger<BaseController<AuditPelRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}