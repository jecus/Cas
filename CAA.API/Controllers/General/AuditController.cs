using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("audit")]
	public class AuditController : BaseController<CAAAuditDTO>
	{
		public AuditController(DataContext context, ILogger<BaseController<CAAAuditDTO>> logger) : base(context, logger)
		{
		}
	}
}