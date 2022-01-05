using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("servicetype")]
	public class ServiceTypeController : BaseDictionaryController<ServiceTypeDTO>
	{
        public ServiceTypeController(DataContext context, ILogger<BaseController<ServiceTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}