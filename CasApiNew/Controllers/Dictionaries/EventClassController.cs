using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("eventclass")]
	public class EventClassController : BaseDictionaryController<EventClassDTO>
	{
        public EventClassController(DataContext context, ILogger<BaseController<EventClassDTO>> logger) : base(context, logger)
		{
			
		}
    }
}