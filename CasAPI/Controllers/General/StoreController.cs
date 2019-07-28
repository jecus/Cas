using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("store")]
	public class StoreController : BaseController<StoreDTO>
	{
		public StoreController(DataContext context, ILogger<BaseController<StoreDTO>> logger) : base(context, logger)
		{

		}
	}
}

