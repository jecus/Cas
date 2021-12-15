using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("audit")]
	public class AuditController : BaseController<AuditDTO>
	{
		public AuditController(DataContext context, ILogger<BaseController<AuditDTO>> logger) : base(context, logger)
		{

		}
	}
}