using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("discrepancy")]
	public class DiscrepancyController : BaseController<DiscrepancyDTO>
	{
		public DiscrepancyController(DataContext context, ILogger<BaseController<DiscrepancyDTO>> logger) : base(context, logger)
		{

		}
	}
}
