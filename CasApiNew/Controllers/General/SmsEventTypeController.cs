using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("smseventtype")]
	public class SmsEventTypeController : BaseController<SmsEventTypeDTO>
	{
		public SmsEventTypeController(DataContext context, ILogger<BaseController<SmsEventTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
