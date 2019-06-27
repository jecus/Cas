using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("ATAChapter")]
	public class ATAChapterController : BaseController<ATAChapterDTO>
	{
		public ATAChapterController(DataContext context, ILogger<BaseController<ATAChapterDTO>> logger) : base(context, logger)
		{
			
		}
	}
}