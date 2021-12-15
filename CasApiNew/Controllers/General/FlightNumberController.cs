using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("flightnumber")]
	public class FlightNumberController : BaseController<FlightNumberDTO>
	{
		public FlightNumberController(DataContext context, ILogger<BaseController<FlightNumberDTO>> logger) : base(context, logger)
		{

		}
	}
}
