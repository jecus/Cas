using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("store")]
	public class StoreController : BaseController<StoreDTO>
	{
		public StoreController(DataContext context, ILogger<BaseController<StoreDTO>> logger) : base(context, logger)
		{

		}
	}
}

