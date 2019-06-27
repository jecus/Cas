using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("workPackageRecord")]
	public class WorkPackageRecordController : BaseController<WorkPackageRecordDTO>
	{
		public WorkPackageRecordController(DataContext context, ILogger<BaseController<WorkPackageRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

