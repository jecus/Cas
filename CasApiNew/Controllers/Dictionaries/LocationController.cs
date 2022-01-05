using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("location")]
	public class LocationController : BaseDictionaryController<LocationDTO>
	{
        public LocationController(DataContext context, ILogger<BaseController<LocationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}