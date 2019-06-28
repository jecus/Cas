using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("workpackage")]
	public class WorkPackageController : BaseController<WorkPackageDTO>
	{
		public WorkPackageController(DataContext context, ILogger<BaseController<WorkPackageDTO>> logger) : base(context, logger)
		{

		}
	}
}
