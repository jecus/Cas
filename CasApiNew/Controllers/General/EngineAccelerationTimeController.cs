using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("engineaccelerationtime")]
	public class EngineAccelerationTimeController : BaseController<EngineAccelerationTimeDTO>
	{
		public EngineAccelerationTimeController(DataContext context, ILogger<BaseController<EngineAccelerationTimeDTO>> logger) : base(context, logger)
		{

		}
	}
}
