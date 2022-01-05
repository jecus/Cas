using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("atachapter")]
	public class ATAChapterController : BaseDictionaryController<CAAATAChapterDTO>
	{
        public ATAChapterController(DataContext context, ILogger<BaseController<CAAATAChapterDTO>> logger) : base(context, logger)
		{
			
		}
    }
}