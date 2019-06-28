using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("stockcomponentinfo")]
	public class StockComponentInfoController : BaseController<StockComponentInfoDTO>
	{
		public StockComponentInfoController(DataContext context, ILogger<BaseController<StockComponentInfoDTO>> logger) : base(context, logger)
		{

		}
	}
}

