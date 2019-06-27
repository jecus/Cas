using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("AGWCategorie")]
	public class AGWCategorieController : BaseController<AGWCategorieDTO>
	{
		public AGWCategorieController(DataContext context, ILogger<BaseController<AGWCategorieDTO>> logger) : base(context, logger)
		{
			
		}
	}
}