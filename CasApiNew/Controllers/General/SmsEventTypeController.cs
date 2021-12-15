using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("smseventtype")]
	public class SmsEventTypeController : BaseController<SmsEventTypeDTO>
	{
		public SmsEventTypeController(DataContext context, ILogger<BaseController<SmsEventTypeDTO>> logger) : base(context, logger)
		{

		}
	}
}
