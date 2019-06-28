using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("arportcode")]
	public class AirportCodeController : BaseController<AirportCodeDTO>
	{
		public AirportCodeController(DataContext context, ILogger<BaseController<AirportCodeDTO>> logger) : base(context, logger)
		{
			
		}
	}
}