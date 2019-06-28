using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("aircraftworkercategory")]
	public class AircraftWorkerCategoryController : BaseController<AircraftWorkerCategoryDTO>
	{
		public AircraftWorkerCategoryController(DataContext context, ILogger<BaseController<AircraftWorkerCategoryDTO>> logger) : base(context, logger)
		{
			
		}
	}
}