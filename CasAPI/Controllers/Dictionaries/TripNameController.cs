using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("tripName")]
	public class TripNameController : BaseController<TripNameDTO>
	{
		public TripNameController(DataContext context, ILogger<BaseController<TripNameDTO>> logger) : base(context, logger)
		{
			
		}
	}
}