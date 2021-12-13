using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workorderrecord")]
	public class WorkOrderRecordController : BaseController<WorkOrderRecordDTO>
	{
		public WorkOrderRecordController(DataContext context, ILogger<BaseController<WorkOrderRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
