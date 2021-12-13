using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("store")]
	public class StoreController : BaseController<StoreDTO>
	{
		public StoreController(DataContext context, ILogger<BaseController<StoreDTO>> logger) : base(context, logger)
		{

		}
	}
}

