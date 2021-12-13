using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workpackagerecord")]
	public class WorkPackageRecordController : BaseController<WorkPackageRecordDTO>
	{
		public WorkPackageRecordController(DataContext context, ILogger<BaseController<WorkPackageRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

