using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workpackagespecialists")]
	public class WorkPackageSpecialistsController : BaseController<WorkPackageSpecialistsDTO>
	{
		public WorkPackageSpecialistsController(DataContext context, ILogger<BaseController<WorkPackageSpecialistsDTO>> logger) : base(context, logger)
		{

		}
	}
}

