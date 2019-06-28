using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("defferedcategorie")]
	public class DefferedCategorieController : BaseController<DefferedCategorieDTO>
	{
		public DefferedCategorieController(DataContext context, ILogger<BaseController<DefferedCategorieDTO>> logger) : base(context, logger)
		{
			
		}
	}
}