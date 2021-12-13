using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workstations")]
	public class WorkStationController : BaseController<WorkStationsDTO>
	{
		public WorkStationController(DataContext context, ILogger<BaseController<WorkStationsDTO>> logger) : base(context, logger)
		{

		}
	}
}

