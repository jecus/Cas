using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("engineaccelerationtime")]
	public class EngineAccelerationTimeController : BaseController<EngineAccelerationTimeDTO>
	{
		public EngineAccelerationTimeController(DataContext context, ILogger<BaseController<EngineAccelerationTimeDTO>> logger) : base(context, logger)
		{

		}
	}
}
