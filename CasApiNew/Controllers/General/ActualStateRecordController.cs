using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("actualstaterecord")]
	public class ActualStateRecordController : BaseController<ActualStateRecordDTO>
	{
		public ActualStateRecordController(DataContext context, ILogger<BaseController<ActualStateRecordDTO>> logger) : base(context, logger)
		{
			
		}
	}
}