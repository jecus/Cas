
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("actualstaterecord")]
	public class ActualStateRecordController : BaseController<ActualStateRecordDTO>
	{
		public ActualStateRecordController(DataContext context, ILogger<BaseController<ActualStateRecordDTO>> logger) : base(context, logger)
		{
			
		}
	}
}