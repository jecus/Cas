using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("jobcardtask")]
	public class JobCardTaskController : BaseController<JobCardTaskDTO>
	{
		public JobCardTaskController(DataContext context, ILogger<BaseController<JobCardTaskDTO>> logger) : base(context, logger)
		{

		}
	}
}

