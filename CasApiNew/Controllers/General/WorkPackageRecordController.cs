using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workpackagerecord")]
	public class WorkPackageRecordController : BaseController<WorkPackageRecordDTO>
	{
		public WorkPackageRecordController(DataContext context, ILogger<BaseController<WorkPackageRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

