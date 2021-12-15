using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workstations")]
	public class WorkStationController : BaseController<WorkStationsDTO>
	{
		public WorkStationController(DataContext context, ILogger<BaseController<WorkStationsDTO>> logger) : base(context, logger)
		{

		}
	}
}

