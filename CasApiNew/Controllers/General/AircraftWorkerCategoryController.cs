using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("aircraftworkercategory")]
	public class AircraftWorkerCategoryController : BaseController<AircraftWorkerCategoryDTO>
	{
		public AircraftWorkerCategoryController(DataContext context, ILogger<BaseController<AircraftWorkerCategoryDTO>> logger) : base(context, logger)
		{
			
		}
	}
}