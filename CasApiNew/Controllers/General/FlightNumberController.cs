using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("flightnumber")]
	public class FlightNumberController : BaseController<FlightNumberDTO>
	{
		public FlightNumberController(DataContext context, ILogger<BaseController<FlightNumberDTO>> logger) : base(context, logger)
		{

		}
	}
}
