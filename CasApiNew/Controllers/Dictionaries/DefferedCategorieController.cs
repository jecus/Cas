using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("defferedcategorie")]
	public class DefferedCategorieController : BaseDictionaryController<DefferedCategorieDTO>
	{

        public DefferedCategorieController(DataContext context, ILogger<BaseController<DefferedCategorieDTO>> logger) : base(context, logger)
		{
			
		}
    }
}