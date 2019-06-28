using Microsoft.AspNetCore.Mvc;

namespace CasAPI.Controllers
{
	[ApiController]
	[Route("monitoring")]
	public class MonitoringController : ControllerBase
	{
		public MonitoringController()
		{
			
		}

		[HttpGet("ping")]
		public ActionResult Ping()
		{
			return Ok();
		}
	}
}