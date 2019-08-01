using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("workpackagespecialists")]
	public class WorkPackageSpecialistsController : BaseController<WorkPackageSpecialistsDTO>
	{
		public WorkPackageSpecialistsController(DataContext context, ILogger<BaseController<WorkPackageSpecialistsDTO>> logger) : base(context, logger)
		{

		}
	}
}

