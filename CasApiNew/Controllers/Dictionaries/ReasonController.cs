using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("reason")]
	public class ReasonController : BaseDictionaryController<ReasonDTO>
	{
        public ReasonController(DataContext context, ILogger<BaseController<ReasonDTO>> logger) : base(context, logger)
		{
			
		}
    }
}