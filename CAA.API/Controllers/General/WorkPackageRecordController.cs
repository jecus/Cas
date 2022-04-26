using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("workpackagerecord")]
	public class WorkPackageRecordController : BaseController<CAAWorkPackageRecordDTO>
	{
		public WorkPackageRecordController(DataContext context, ILogger<BaseController<CAAWorkPackageRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}