using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("smsEventType")]
	public class SmsEventTypeController : BaseController<SmsEventTypeDTO>
	{
		public SmsEventTypeController(DataContext context, ILogger<BaseController<SmsEventTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
