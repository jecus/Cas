using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("servicetype")]
	public class ServiceTypeController : BaseDictionaryController<CAAServiceTypeDTO>
	{

        public ServiceTypeController(DataContext context, ILogger<BaseController<CAAServiceTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}