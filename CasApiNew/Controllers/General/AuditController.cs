using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("audit")]
	public class AuditController : BaseController<AuditDTO>
	{
		public AuditController(DataContext context, ILogger<BaseController<AuditDTO>> logger) : base(context, logger)
		{

		}
	}
}