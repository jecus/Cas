using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("findinglevels")]
	public class FindingLevelsController : BaseDictionaryController<FindingLevelsDTO>
	{
        public FindingLevelsController(DataContext context, ILogger<BaseController<FindingLevelsDTO>> logger) : base(context, logger)
		{
			
		}

	}
}