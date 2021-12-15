using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("jobcard")]
	public class JobCardController : BaseController<JobCardDTO>
	{
		public JobCardController(DataContext context, ILogger<BaseController<JobCardDTO>> logger) : base(context, logger)
		{

		}
	}
}
