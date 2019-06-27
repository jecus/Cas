using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("restriction")]
	public class RestrictionController : BaseController<RestrictionDTO>
	{
		public RestrictionController(DataContext context, ILogger<BaseController<RestrictionDTO>> logger) : base(context, logger)
		{
			
		}
	}
}