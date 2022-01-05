using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("locationstype")]
	public class LocationsTypeController : BaseDictionaryController<CAALocationsTypeDTO>
	{
        public LocationsTypeController(DataContext context, ILogger<BaseController<CAALocationsTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}