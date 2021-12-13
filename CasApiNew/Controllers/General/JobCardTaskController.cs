using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("jobcardtask")]
	public class JobCardTaskController : BaseController<JobCardTaskDTO>
	{
		public JobCardTaskController(DataContext context, ILogger<BaseController<JobCardTaskDTO>> logger) : base(context, logger)
		{

		}
	}
}

