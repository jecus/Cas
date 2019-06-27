using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("location")]
	public class LocationController : BaseController<LocationDTO>
	{
		public LocationController(DataContext context, ILogger<BaseController<LocationDTO>> logger) : base(context, logger)
		{
			
		}
	}
}