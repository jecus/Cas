using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("damagechart")]
	public class DamageChartController : BaseDictionaryController<DamageChartDTO>
	{

        public DamageChartController(DataContext context, ILogger<BaseController<DamageChartDTO>> logger) : base(context, logger)
		{
			
		}
    }
}