using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("stockcomponentinfo")]
	public class StockComponentInfoController : BaseController<StockComponentInfoDTO>
	{
		public StockComponentInfoController(DataContext context, ILogger<BaseController<StockComponentInfoDTO>> logger) : base(context, logger)
		{

		}
	}
}

