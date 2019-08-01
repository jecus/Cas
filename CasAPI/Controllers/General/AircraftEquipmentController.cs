using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("aircraftequipment")]
	public class AircraftEquipmentController : BaseController<AircraftEquipmentDTO>
	{
		public AircraftEquipmentController(DataContext context, ILogger<BaseController<AircraftEquipmentDTO>> logger) : base(context, logger)
		{
			
		}
	}
}