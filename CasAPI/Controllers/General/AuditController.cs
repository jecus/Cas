using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("audit")]
	public class AuditController : BaseController<AuditDTO>
	{
		public AuditController(DataContext context, ILogger<BaseController<AuditDTO>> logger) : base(context, logger)
		{

		}
	}
}