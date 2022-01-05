using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("nonroutinejob")]
	public class NonRoutineJobController : BaseDictionaryController<NonRoutineJobDTO>
	{
        public NonRoutineJobController(DataContext context, ILogger<BaseController<NonRoutineJobDTO>> logger) : base(context, logger)
		{
			
		}
    }
}