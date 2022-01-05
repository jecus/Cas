using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("restriction")]
	public class RestrictionController : BaseDictionaryController<CAARestrictionDTO>
	{

        public RestrictionController(DataContext context, ILogger<BaseController<CAARestrictionDTO>> logger) : base(context, logger)
		{
			
		}
    }
}