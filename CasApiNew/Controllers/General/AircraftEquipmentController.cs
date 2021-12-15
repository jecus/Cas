﻿using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("aircraftequipment")]
	public class AircraftEquipmentController : BaseController<AircraftEquipmentDTO>
	{
		public AircraftEquipmentController(DataContext context, ILogger<BaseController<AircraftEquipmentDTO>> logger) : base(context, logger)
		{
			
		}
	}
}