using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("operator")]
	public class OperatorController : BaseController<CAAOperatorDTO>
	{
		public OperatorController(DataContext context, ILogger<BaseController<CAAOperatorDTO>> logger) : base(context, logger)
		{

		}
	}
}
