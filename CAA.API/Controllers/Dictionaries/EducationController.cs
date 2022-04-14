using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("task")]
	public class EducationController : BaseDictionaryController<EducationDTO>
	{

        public EducationController(DataContext context, ILogger<BaseController<EducationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}