using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("checklistrevision")]
	public class CheckListRevisionController : BaseController<CheckListRevisionDTO>
	{
		public CheckListRevisionController(DataContext context, ILogger<BaseController<CheckListRevisionDTO>> logger) : base(context, logger)
		{
		}
	}
	
	[Route("checklistrevisionrecord")]
	public class CheckListRevisionRecordController : BaseController<CheckListRevisionRecordDTO>
	{
		public CheckListRevisionRecordController(DataContext context, ILogger<BaseController<CheckListRevisionRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}