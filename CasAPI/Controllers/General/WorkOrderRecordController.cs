using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("workorderrecord")]
	public class WorkOrderRecordController : BaseController<WorkOrderRecordDTO>
	{
		public WorkOrderRecordController(DataContext context, ILogger<BaseController<WorkOrderRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
