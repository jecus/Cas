using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workorderrecord")]
	public class WorkOrderRecordController : BaseController<WorkOrderRecordDTO>
	{
		public WorkOrderRecordController(DataContext context, ILogger<BaseController<WorkOrderRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
