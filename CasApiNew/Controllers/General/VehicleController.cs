using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("vehicle")]
	public class VehicleController : BaseController<VehicleDTO>
	{
		public VehicleController(DataContext context, ILogger<BaseController<VehicleDTO>> logger) : base(context, logger)
		{

		}
	}
}

