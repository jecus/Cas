using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("agwcategorie")]
	public class AGWCategorieController : BaseDictionaryController<CAAAGWCategorieDTO>
	{
        public AGWCategorieController(DataContext context, ILogger<BaseController<CAAAGWCategorieDTO>> logger) : base(context, logger)
		{
			
		}
    }
}