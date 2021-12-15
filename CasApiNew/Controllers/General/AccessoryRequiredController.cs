using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("accessoryrequired")]
	public class AccessoryRequiredController : BaseController<AccessoryRequiredDTO>
	{
		public AccessoryRequiredController(DataContext context, ILogger<BaseController<AccessoryRequiredDTO>> logger) : base(context, logger)
		{
			
		}
	}
}