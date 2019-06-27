using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("jobCard")]
	public class JobCardController : BaseController<JobCardDTO>
	{
		public JobCardController(DataContext context, ILogger<BaseController<JobCardDTO>> logger) : base(context, logger)
		{

		}
	}
}
