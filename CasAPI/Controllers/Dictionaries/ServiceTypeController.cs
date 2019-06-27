using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("serviceType")]
	public class ServiceTypeController : BaseController<ServiceTypeDTO>
	{
		public ServiceTypeController(DataContext context, ILogger<BaseController<ServiceTypeDTO>> logger) : base(context, logger)
		{
			
		}
	}
}