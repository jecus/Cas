using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("specialization")]
	public class SpecializationController : BaseDictionaryController<SpecializationDTO>
	{

        public SpecializationController(DataContext context, ILogger<BaseController<SpecializationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}