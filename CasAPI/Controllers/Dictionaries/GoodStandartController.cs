using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("goodStandart")]
	public class GoodStandartController : BaseController<GoodStandartDTO>
	{
		public GoodStandartController(DataContext context, ILogger<BaseController<GoodStandartDTO>> logger) : base(context, logger)
		{
			
		}
	}
}