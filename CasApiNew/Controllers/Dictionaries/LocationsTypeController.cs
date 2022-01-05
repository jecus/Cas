using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("locationstype")]
	public class LocationsTypeController : BaseDictionaryController<LocationsTypeDTO>
	{

        public LocationsTypeController(DataContext context, ILogger<BaseController<LocationsTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}