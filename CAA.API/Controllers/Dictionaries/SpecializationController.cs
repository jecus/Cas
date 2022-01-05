using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("specialization")]
	public class SpecializationController : BaseDictionaryController<CAASpecializationDTO>
	{
        public SpecializationController(DataContext context, ILogger<BaseController<CAASpecializationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}