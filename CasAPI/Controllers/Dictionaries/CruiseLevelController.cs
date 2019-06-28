using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("cruiselevel")]
	public class CruiseLevelController : BaseController<CruiseLevelDTO>
	{
		public CruiseLevelController(DataContext context, ILogger<BaseController<CruiseLevelDTO>> logger) : base(context, logger)
		{
			
		}
	}
}