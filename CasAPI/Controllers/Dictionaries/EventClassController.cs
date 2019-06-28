using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("eventclass")]
	public class EventClassController : BaseController<EventClassDTO>
	{
		public EventClassController(DataContext context, ILogger<BaseController<EventClassDTO>> logger) : base(context, logger)
		{
			
		}
	}
}