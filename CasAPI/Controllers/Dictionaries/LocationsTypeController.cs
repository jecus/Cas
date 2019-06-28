using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("locationstype")]
	public class LocationsTypeController : BaseController<LocationsTypeDTO>
	{
		public LocationsTypeController(DataContext context, ILogger<BaseController<LocationsTypeDTO>> logger) : base(context, logger)
		{
			
		}
	}
}