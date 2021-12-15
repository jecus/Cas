using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("aircraftworkercategory")]
	public class AircraftWorkerCategoryController : BaseController<AircraftWorkerCategoryDTO>
	{
		public AircraftWorkerCategoryController(DataContext context, ILogger<BaseController<AircraftWorkerCategoryDTO>> logger) : base(context, logger)
		{
			
		}
	}
}