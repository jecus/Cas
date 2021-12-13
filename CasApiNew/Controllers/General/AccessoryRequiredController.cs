
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("accessoryrequired")]
	public class AccessoryRequiredController : BaseController<AccessoryRequiredDTO>
	{
		public AccessoryRequiredController(DataContext context, ILogger<BaseController<AccessoryRequiredDTO>> logger) : base(context, logger)
		{
			
		}
	}
}