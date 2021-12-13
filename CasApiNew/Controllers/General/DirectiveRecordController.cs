using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("directiverecord")]
	public class DirectiveRecordController : BaseController<DirectiveRecordDTO>
	{
		public DirectiveRecordController(DataContext context, ILogger<BaseController<DirectiveRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
