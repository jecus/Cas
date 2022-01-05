using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("goodstandart")]
	public class GoodStandartController : BaseDictionaryController<GoodStandartDTO>
	{
        public GoodStandartController(DataContext context, ILogger<BaseController<GoodStandartDTO>> logger) : base(context, logger)
		{
			
		}
    }
}