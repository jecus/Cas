using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("atachapter")]
	public class ATAChapterController : BaseDictionaryController<ATAChapterDTO>
	{

        public ATAChapterController(DataContext context, ILogger<BaseController<ATAChapterDTO>> logger) : base(context, logger)
		{
			
		}
    }
}