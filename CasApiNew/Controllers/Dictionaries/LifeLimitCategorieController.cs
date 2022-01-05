using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("lifeLimitcategorie")]
	public class LifeLimitCategorieController : BaseDictionaryController<LifeLimitCategorieDTO>
	{

        public LifeLimitCategorieController(DataContext context, ILogger<BaseController<LifeLimitCategorieDTO>> logger) : base(context, logger)
		{
			
		}
    }
}