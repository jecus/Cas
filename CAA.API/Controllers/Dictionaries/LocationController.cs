using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("location")]
	public class LocationController : BaseDictionaryController<CAALocationDTO>
	{
        public LocationController(DataContext context, ILogger<BaseController<CAALocationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}