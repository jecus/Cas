using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("goodstandart")]
	public class GoodStandartController : BaseDictionaryController<CAAGoodStandartDTO>
	{
        public GoodStandartController(DataContext context, ILogger<BaseController<CAAGoodStandartDTO>> logger) : base(context, logger)
		{
			
		}
    }
}