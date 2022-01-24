using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("auditcheck")]
	public class AuditCheckController : BaseController<AuditCheckDTO>
	{
		public AuditCheckController(DataContext context, ILogger<BaseController<AuditCheckDTO>> logger) : base(context, logger)
		{
		}
	}
}