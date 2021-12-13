using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("engineaccelerationtime")]
	public class EngineAccelerationTimeController : BaseController<EngineAccelerationTimeDTO>
	{
		public EngineAccelerationTimeController(DataContext context, ILogger<BaseController<EngineAccelerationTimeDTO>> logger) : base(context, logger)
		{

		}
	}
}
