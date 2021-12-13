using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workorder")]
	public class WorkOrderController : BaseController<WorkOrderDTO>
	{
		public WorkOrderController(DataContext context, ILogger<BaseController<WorkOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
