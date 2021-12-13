using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("vehicle")]
	public class VehicleController : BaseController<VehicleDTO>
	{
		public VehicleController(DataContext context, ILogger<BaseController<VehicleDTO>> logger) : base(context, logger)
		{

		}
	}
}

