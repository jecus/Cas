using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("initialorder")]
	public class InitialOrderController : BaseController<InitialOrderDTO>
	{
		public InitialOrderController(DataContext context, ILogger<BaseController<InitialOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
