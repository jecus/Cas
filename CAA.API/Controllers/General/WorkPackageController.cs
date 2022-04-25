using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("workpackage")]
	public class WorkPackageController : BaseController<CAAWorkPackageDTO>
	{
		public WorkPackageController(DataContext context, ILogger<BaseController<CAAWorkPackageDTO>> logger) : base(context, logger)
		{
		}
	}
}