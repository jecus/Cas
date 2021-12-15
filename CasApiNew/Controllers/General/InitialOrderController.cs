using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("initialorder")]
	public class InitialOrderController : BaseController<InitialOrderDTO>
	{
		public InitialOrderController(DataContext context, ILogger<BaseController<InitialOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
