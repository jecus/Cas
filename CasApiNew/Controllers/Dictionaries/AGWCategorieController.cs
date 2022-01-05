using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("agwcategorie")]
	public class AGWCategorieController : BaseDictionaryController<AGWCategorieDTO>
	{

        public AGWCategorieController(DataContext context, ILogger<BaseController<AGWCategorieDTO>> logger) : base(context, logger)
		{
			
		}
    }
}