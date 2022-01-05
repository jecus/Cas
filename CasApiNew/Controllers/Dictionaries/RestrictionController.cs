using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("restriction")]
	public class RestrictionController : BaseDictionaryController<RestrictionDTO>
	{
        public RestrictionController(DataContext context, ILogger<BaseController<RestrictionDTO>> logger) : base(context, logger)
		{
			
		}
    }
}