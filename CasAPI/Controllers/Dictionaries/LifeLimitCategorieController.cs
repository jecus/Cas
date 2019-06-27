using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("lifeLimitCategorie")]
	public class LifeLimitCategorieController : BaseController<LifeLimitCategorieDTO>
	{
		public LifeLimitCategorieController(DataContext context, ILogger<BaseController<LifeLimitCategorieDTO>> logger) : base(context, logger)
		{
			
		}
	}
}