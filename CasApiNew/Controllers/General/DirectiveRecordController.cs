using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("directiverecord")]
	public class DirectiveRecordController : BaseController<DirectiveRecordDTO>
	{
		public DirectiveRecordController(DataContext context, ILogger<BaseController<DirectiveRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
