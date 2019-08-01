using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("accessoryrequired")]
	public class AccessoryRequiredController : BaseController<AccessoryRequiredDTO>
	{
		public AccessoryRequiredController(DataContext context, ILogger<BaseController<AccessoryRequiredDTO>> logger) : base(context, logger)
		{
			
		}
	}
}