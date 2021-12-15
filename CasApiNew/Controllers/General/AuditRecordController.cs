using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("auditrecord")]
	public class AuditRecordController : BaseController<AuditRecordDTO>
	{
		public AuditRecordController(DataContext context, ILogger<BaseController<AuditRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}