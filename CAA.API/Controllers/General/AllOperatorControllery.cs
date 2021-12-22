using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("alloperators")]
	public class AllOperatorControllery : BaseController<AllOperatorsDTO>
	{
		public AllOperatorControllery(DataContext context, ILogger<BaseController<AllOperatorsDTO>> logger) : base(context, logger)
		{

		}
	}
}
