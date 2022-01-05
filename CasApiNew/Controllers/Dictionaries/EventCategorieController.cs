using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("eventcategorie")]
	public class EventCategorieController : BaseDictionaryController<EventCategorieDTO>
	{
        public EventCategorieController(DataContext context, ILogger<BaseController<EventCategorieDTO>> logger) : base(context, logger)
		{
			
		}
    }
}