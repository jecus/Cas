using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("auditrecord")]
	public class AuditRecordController : BaseController<AuditRecordDTO>
	{
		public AuditRecordController(DataContext context, ILogger<BaseController<AuditRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}