using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("DirectiveRecord")]
	public class DirectiveRecordController : BaseController<DirectiveRecordDTO>
	{
		public DirectiveRecordController(DataContext context, ILogger<BaseController<DirectiveRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
