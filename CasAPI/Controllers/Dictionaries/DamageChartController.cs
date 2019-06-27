using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("damageChart")]
	public class DamageChartController : BaseController<DamageChartDTO>
	{
		public DamageChartController(DataContext context, ILogger<BaseController<DamageChartDTO>> logger) : base(context, logger)
		{
			
		}
	}
}