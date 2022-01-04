using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("checklistrecord")]
	public class CheckListRecordController : BaseController<CheckListRecordDTO>
	{
		public CheckListRecordController(DataContext context, ILogger<BaseController<CheckListRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}