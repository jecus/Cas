using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("jobCardTask")]
	public class JobCardTaskController : BaseController<JobCardTaskDTO>
	{
		public JobCardTaskController(DataContext context, ILogger<BaseController<JobCardTaskDTO>> logger) : base(context, logger)
		{

		}
	}
}

