using System;
using System.Linq;
using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Z.EntityFramework.Plus;

namespace CasAPI.Controllers.General
{
	[Route("aircraft")]
	public class AircraftController : BaseController<AircraftDTO>
	{
		public AircraftController(DataContext context, ILogger<BaseController<AircraftDTO>> logger) : base(context, logger)
		{
		}
	}
}