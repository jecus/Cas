using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("vehicle")]
	public class VehicleController : BaseController<VehicleDTO>
	{
		public VehicleController(DataContext context, ILogger<BaseController<VehicleDTO>> logger) : base(context, logger)
		{

		}
	}
}

