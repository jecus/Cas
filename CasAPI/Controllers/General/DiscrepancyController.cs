using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("discrepancy")]
	public class DiscrepancyController : BaseController<DiscrepancyDTO>
	{
		public DiscrepancyController(DataContext context, ILogger<BaseController<DiscrepancyDTO>> logger) : base(context, logger)
		{

		}
	}
}
