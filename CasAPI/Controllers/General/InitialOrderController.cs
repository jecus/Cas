using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("initialorder")]
	public class InitialOrderController : BaseController<InitialOrderDTO>
	{
		public InitialOrderController(DataContext context, ILogger<BaseController<InitialOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
