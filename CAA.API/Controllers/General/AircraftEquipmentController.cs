using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("aircraftequipment")]
	public class AircraftEquipmentController : BaseController<CAAAircraftEquipmentDTO>
	{
		public AircraftEquipmentController(DataContext context, ILogger<BaseController<CAAAircraftEquipmentDTO>> logger) : base(context, logger)
		{
			
		}
	}
}