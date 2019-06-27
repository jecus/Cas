using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("reason")]
	public class ReasonController : BaseController<ReasonDTO>
	{
		public ReasonController(DataContext context, ILogger<BaseController<ReasonDTO>> logger) : base(context, logger)
		{
			
		}
	}
}